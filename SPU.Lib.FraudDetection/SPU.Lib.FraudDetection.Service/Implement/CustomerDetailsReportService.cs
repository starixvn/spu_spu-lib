using System.Globalization;

namespace FD.Lib.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.Reports.CustomerDetails;
    using Criteria.SuspiciousStatistic;
    using DataAccess.Implement;
    using DataAccess.Interface;
    using DTO.CustomerDetails;
    using Fanex.BetList.Core.Builder;
    using Fanex.BetList.Core.TicketHelper;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;
    using Model.Reports.CustomerDetails;
    using Model.Reports.FraudCaseDetail;
    using RemotingRef;

    /// <summary>
    /// Customer Details Report Service.
    /// </summary>
    public class CustomerDetailsReportService : QueryService, ICustomerDetailsReportService
    {
        private readonly IMoveBetsBalanceUpService _balanceUpService;

        private readonly ICustomerDetailsReportDataAccess _customerDetailsDataAccess;

        public CustomerDetailsReportService()
        {
            _balanceUpService = new MoveBetsBalanceUpService();
            _customerDetailsDataAccess = new CustomerDetailsReportDataAccess();
        }

        public CustomerDetailsModel GetCustomerDetailsModel(
            int custId,
            DateTime fromDate,
            DateTime toDate,
            bool isTest)
        {
            //var customerDetailsModel = GetWinlossStatistic(new CustomerDetailsReportWinlossStatisticCriteria(custId, fromDate, toDate));
            var customerDetailsModel = new CustomerDetailsModel
                {

                    CustInfo = GetCustomerInfo(new CustomerDetailsReportCustInfoCriteria(custId)),
                    FraudCasesDetails =
                        GetFraudCasesDetails(new CustomerDetailsReportFraudCaseCriteria(custId, fromDate, toDate)),
                    LogsNotesDetails = GetLogsNotes(new CustomerDetailsReportLogNoteCriteria(custId)),
                    ViolatedTickets = GetFraudTickets(custId, fromDate, toDate, isTest)
                };

            return customerDetailsModel;
        }

        public CustomerDetailsModel GetWinlossStatistic(CustomerDetailsReportWinlossStatisticCriteria criteria)
        {
            return _customerDetailsDataAccess.GetCustomerDetailWinlossStatistic(criteria);
        }

        public CustomerInfo GetCustomerInfo(ICriteria criteria)
        {
            return GetData<CustomerInfo>(criteria).First();
        }

        public IEnumerable<SuspiciousInfoDetails> GetSuspiciousInfoByCustId(ICriteria criteria)
        {
            return GetData<SuspiciousInfoDetails>(criteria);
        }

        public IEnumerable<FraudCaseDetails> GetFraudCasesDetails(ICriteria criteria)
        {
            return GetData<FraudCaseDetails>(criteria);
        }

        public IEnumerable<LogsNotes> GetLogsNotes(ICriteria criteria)
        {
            return GetData<LogsNotes>(criteria);
        }

        public WinlossStatisticSummary GetWinlossStatisticSummary(ICriteria criteria)
        {
            return GetData<WinlossStatisticSummary>(criteria).FirstOrDefault();
        }

        public IEnumerable<WinlossStatisticEventChoice> GetEventChoice(ICriteria criteria)
        {
            return GetData<WinlossStatisticEventChoice>(criteria);
        }

        public IEnumerable<WinlossStatisticTopSports> GetTopSportsByMargin(ICriteria criteria)
        {
            return GetData<WinlossStatisticTopSports>(criteria);
        }

        public IEnumerable<WinlossStatisticTopBettypes> GetTopBettypeByMargin(ICriteria criteria)
        {
            return GetData<WinlossStatisticTopBettypes>(criteria);
        }

        public IEnumerable<FraudCaseDetailItem> GetFraudTickets(int custId, DateTime fromDate, DateTime toDate, bool isTest)
        {
            var moveBetBalanceUp = _balanceUpService.GetBalanceUpDay(new BalanceUpDaySelectCriteria());
            var criteria = new CustomerDetailsReportTransListCriteria(custId, fromDate, toDate);
            criteria.IsTest = isTest;
            var suspiciousDetails = GetSuspiciousInfoByCustId(criteria);
            var suspiciousTickets = new List<FraudTicketModel>();

            foreach (var suspiciousDetail in suspiciousDetails)
            {
                if (suspiciousDetail.EventDate > moveBetBalanceUp.BalanceUpDay)
                {
                    var tickets = GetSuspiciousTicketFromBodb02(new CustomerDetailsReportFraudTicketsCriteria
                    {
                        FromDate = fromDate,
                        ToDate = toDate,
                        MoveBetDate = moveBetBalanceUp.MoveBetsDay,
                        MatchId = suspiciousDetail.MatchId,
                        WinlostDate = suspiciousDetail.EventDate,
                        TransList = suspiciousDetail.TransList
                    }).ToList();

                    tickets.Select(t =>
                    {
                        t.CaseId = suspiciousDetail.CaseId;
                        t.CaseName = suspiciousDetail.CaseName;
                        return t;
                    }).ToList();

                    suspiciousTickets.AddRange(tickets);
                }
                else
                {
                    var tickets = GetSuspiciousTicketsFromBodbArchieve(new CustomerDetailsReportFraudTicketsFromDbArchiveCriteria
                    {
                        MatchId = suspiciousDetail.MatchId,
                        WinlostDate = suspiciousDetail.EventDate,
                        TransList = suspiciousDetail.TransList
                    }).ToList();

                    tickets.Select(t =>
                    {
                        t.CaseId = suspiciousDetail.CaseId;
                        t.CaseName = suspiciousDetail.CaseName;
                        return t;
                    }).ToList();

                    suspiciousTickets.AddRange(tickets);
                }
            }

            var result = GetChoiceForSuspiciousTickets(suspiciousTickets);

            return result;
        }

        public FraudCaseDetailBetListViewModel GetFraudTicketsByIp(string ip)
        {
            var moveBetBalanceUp = _balanceUpService.GetBalanceUpDay(new BalanceUpDaySelectCriteria());
            var tickets = new List<FraudTicketModel>();
            BetTicketByIpCriteria criteria = new BetTicketByIpCriteria()
            {
                Ip = ip
            };
            tickets = GetDataOutput<FraudTicketModel>(criteria).ToList();
            var result = new FraudCaseDetailBetListViewModel()
            {
                BalanceUpDay = moveBetBalanceUp.BalanceUpDay,
                BetList = GetChoiceForSuspiciousTickets(tickets)
            };

            return result;
        }

        public IList<FraudTicketModel> GetSuspiciousTicketFromBodb02(CustomerDetailsReportFraudTicketsCriteria criteria)
        {
            return GetDataOutput<FraudTicketModel>(criteria).ToList();
        }

        public IList<FraudTicketModel> GetSuspiciousTicketsFromBodbArchieve(CustomerDetailsReportFraudTicketsFromDbArchiveCriteria criteria)
        {
            return GetDataOutput<FraudTicketModel>(criteria).ToList();
        }

        public IEnumerable<FraudCaseDetailItem> GetChoiceForSuspiciousTickets(IEnumerable<FraudTicketModel> suspiciousTickets)
        {
            var builder = new BetListHTMLBuilder();
            var ticketHelper = new TicketHelper();

            var list = new List<FraudCaseDetailItem>();

            foreach (var ticket in suspiciousTickets)
            {
                var item = new FraudCaseDetailItem
                {
                    HomeName = RefData.GetTeamName(ticket.HomeId.ToString(CultureInfo.InvariantCulture), "en", string.Empty),
                    AwayName = RefData.GetTeamName(ticket.AwayId.ToString(CultureInfo.InvariantCulture), "en", string.Empty),
                    BetType = RefData.GetBetTypeName(ticket.BetTypeId.ToString(CultureInfo.InvariantCulture), "en", string.Empty),
                    Choice = builder.BuildChoice(ticket, ticketHelper, null, false),
                    CustName = ticket.UserName,
                    CaseId = ticket.CaseId,
                    CaseName = ticket.CaseName,
                    IP = ticket.IP,
                    Odds = builder.BuildOdds(ticket, null, CacheRef.GetOddsTypeName),
                    Stake = builder.BuildStake(ticket),
                    WinLoss = ticket.Winlost,
                    Score = FormatScore(ticket),
                    Status = ticket.Status,
                    TransDate = ticket.TransDate.ToString(CultureInfo.InvariantCulture),
                    TransId = ticket.TransId
                };

                list.Add(item);
            }

            return list.OrderBy(t => t.CustName).ToList();
        }

        public ICommandResult InsertCustomerLog(ICriteria criteria)
        {
            return _customerDetailsDataAccess.InsertCustomerLog(criteria);
        }

        public ICommandResult InsertCustomerNote(ICriteria criteria)
        {
            return _customerDetailsDataAccess.InsertCustomerNote(criteria);
        }

        public ICommandResult RemoveCustomerLogNote(ICriteria criteria)
        {
            return _customerDetailsDataAccess.RemoveCustomerLogNote(criteria);
        }

        public ICommandResult UpdateCustomerDelinquent(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult UpdateCustomerHedge(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public List<int> GetViolatedCases(ICriteria criteria)
        {
            return _customerDetailsDataAccess.GetViolatedCases(criteria);
        }

        public ICommandResult InsertAssignees(ICriteria criteria)
        {
            return _customerDetailsDataAccess.InsertAssignees(criteria);
        }

        public string GetAssignees(ICriteria criteria)
        {
            return GetData<string>(criteria).FirstOrDefault();
        }

        private string FormatScore(FraudTicketModel ticket)
        {
            var result = "HT: {0}<br><b>FT: {1}</b>";
            var halfTimeScore = "{0} - {1}";
            var fullTimeScore = "{0} - {1}";

            if (ticket.HalfTimeHomeScore == null || ticket.HalfTimeAwayScore == null)
            {
                halfTimeScore = string.Format(halfTimeScore, "", "");
            }
            else
            {
                halfTimeScore = string.Format(halfTimeScore, ticket.HalfTimeHomeScore, ticket.HalfTimeAwayScore);
            }

            if (ticket.FullTimeHomeScore == null || ticket.FullTimeAwayScore == null)
            {
                fullTimeScore = string.Format(fullTimeScore, "", "");
            }
            else
            {
                fullTimeScore = string.Format(fullTimeScore, ticket.FullTimeHomeScore, ticket.FullTimeAwayScore);
            }

            result = string.Format(result, halfTimeScore, fullTimeScore);

            return result;
        }

        public IEnumerable<MarginModel> GetMonthlyWinloss(ICriteria criteria)
        {
            return GetData<MarginModel>(criteria);
        }
    }
}