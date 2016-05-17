// --------------------------------------------------------------------------
// <copyright file="ICustomerDetailsReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.12.14">Created</change>
// </history>

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
            DateTime toDate)
        {
            //var customerDetailsModel = GetWinlossStatistic(new CustomerDetailsReportWinlossStatisticCriteria(custId, fromDate, toDate));
            var customerDetailsModel = new CustomerDetailsModel
                {

                    CustInfo = GetCustomerInfo(new CustomerDetailsReportCustInfoCriteria(custId)),
                    FraudCasesDetails =
                        GetFraudCasesDetails(new CustomerDetailsReportFraudCaseCriteria(custId, fromDate, toDate)),
                    LogsNotesDetails = GetLogsNotes(new CustomerDetailsReportLogNoteCriteria(custId)),
                    ViolatedTickets = GetFraudTickets(custId, fromDate, toDate)
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

        public IEnumerable<FraudCaseDetailItem> GetFraudTickets(int custId, DateTime fromDate, DateTime toDate)
        {
            var moveBetBalanceUp = _balanceUpService.GetBalanceUpDay(new BalanceUpDaySelectCriteria());
            var suspiciousDetails = GetSuspiciousInfoByCustId(new CustomerDetailsReportTransListCriteria(custId, fromDate, toDate)).ToList();
            var suspiciousTickets = new List<FraudTicketModel>();

            foreach (var susp in suspiciousDetails)
            {
                suspiciousTickets.AddRange(susp.EventDate > moveBetBalanceUp.BalanceUpDay
                    ? GetSuspiciousTicketFromBodb02(new CustomerDetailsReportFraudTicketsCriteria
                        {
                            FromDate = fromDate,
                            ToDate = toDate,
                            MoveBetDate = moveBetBalanceUp.MoveBetsDay,
                            MatchId = susp.MatchId,
                            WinlostDate = susp.EventDate,
                            TransList = susp.TransList
                        }).ToList()
                    : GetSuspiciousTicketsFromBodbArchieve(new CustomerDetailsReportFraudTicketsFromDbArchiveCriteria
                        {
                            MatchId = susp.MatchId,
                            WinlostDate = susp.EventDate,
                            TransList = susp.TransList
                        }).ToList());
            }

            return GetChoiceForSuspiciousTickets(suspiciousTickets);
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
            return _customerDetailsDataAccess.UpdateCustomerDelinquent(criteria);
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
            var result = string.Format("HT: {0} - {1}<br><b>FT: {2} - {3}</b>", ticket.HalfTimeHomeScore, ticket.HalfTimeAwayScore,
                                   ticket.FullTimeHomeScore, ticket.FullTimeAwayScore);

            return result;
        }
    }
}