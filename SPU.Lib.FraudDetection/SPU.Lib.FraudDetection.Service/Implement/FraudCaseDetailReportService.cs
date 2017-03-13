namespace FD.Lib.Service.Implement
{
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.Reports;
    using Criteria.SuspiciousStatistic;
    using DTO;
    using Fanex.BetList.Core.Builder;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.TicketHelper;
    using Interface;
    using Model.Reports.FraudCaseDetail;
    using RemotingRef;

    /// <summary>
    /// Fraud Case Detail Report Service.
    /// </summary>
    public class FraudCaseDetailReportService : QueryService, IFraudCaseDetailReportService
    {
        private readonly IMoveBetsBalanceUpService _balanceUpService;

        public FraudCaseDetailReportService()
        {
            _balanceUpService = new MoveBetsBalanceUpService();
        }

        /// <summary>
        /// Get Fraud Case Details.
        /// </summary>
        /// <param name="criteria">Criteria input.</param>
        /// <param name="getDataForExcelFile">Check whether getting data for exporting to Excel file.</param>
        /// <returns>Fraud Case Detail Report Model.</returns>
        public FraudCaseDetailReportViewModel GetFraudCaseDetails(FraudCaseDetailReportCriteria criteria, bool getDataForExcelFile = false)
        {
            var moveBetBalanceUp = _balanceUpService.GetBalanceUpDay(new BalanceUpDaySelectCriteria());

            var summary = GetFraudCaseDetailSummary(criteria);

            var suspiciousTickets = GetSuspiciousTickets(criteria, moveBetBalanceUp, summary);

            var list = getDataForExcelFile ? BuildTicketsForExportToExcel(suspiciousTickets, criteria.Bettype) : GetChoiceForSuspiciousTickets(suspiciousTickets);

            FraudCaseDetailReportViewModel result = new FraudCaseDetailReportViewModel()
            {
                Summary = summary,
                Body = list
            };
            return result;
        }

        private List<FraudCaseDetailByBetTypeList> GetChoiceForSuspiciousTickets(IList<Ticket> suspiciousTickets)
        {
            var builder = new BetListHTMLBuilder();
            var ticketHelper = new TicketHelper();

            var list = new List<FraudCaseDetailItem>();
            var result = new List<FraudCaseDetailByBetTypeList>();

            foreach (var ticket in suspiciousTickets)
            {
                var item = new FraudCaseDetailItem
                {
                    HomeName = RefData.GetTeamName(ticket.HomeId.ToString(), "en", string.Empty),
                    AwayName = RefData.GetTeamName(ticket.AwayId.ToString(), "en", string.Empty),
                    BetType = RefData.GetBetTypeName(ticket.BetTypeId.ToString(), "en", string.Empty),
                    Choice = builder.BuildChoice(ticket, ticketHelper, null, false),
                    CustName = ticket.UserName,
                    IP = ticket.IP,
                    Odds = builder.BuildOdds(ticket, null, CacheRef.GetOddsTypeName),
                    Stake = builder.BuildStake(ticket),
                    WinLoss = ticket.Winlost,
                    Score = string.Format("{0} - {1}", ticket.LiveHomeScore, ticket.LiveAwayScore),
                    Status = ticket.Status,
                    TransDate = ticket.TransDate.ToString(),
                    TransId = ticket.TransId
                };

                list.Add(item);
            }

            var groupedList = list.GroupBy(x => x.BetType).ToList();
            foreach (var item in groupedList)
            {
                FraudCaseDetailByBetTypeList listDetail = new FraudCaseDetailByBetTypeList()
                {
                    Bettype = item.Key,
                    FraudCaseDetailList = item
                };
                result.Add(listDetail);
            }

            return result;
        }

        private List<FraudCaseDetailByBetTypeList> BuildTicketsForExportToExcel(IList<Ticket> suspiciousTickets, string bettype)
        {
            var list = new List<FraudCaseDetailItem>();
            var result = new List<FraudCaseDetailByBetTypeList>();

            foreach (var ticket in suspiciousTickets)
            {
                var item = new FraudCaseDetailItem
                {
                    HomeName = RefData.GetTeamName(ticket.HomeId.ToString(), "en", string.Empty),
                    AwayName = RefData.GetTeamName(ticket.AwayId.ToString(), "en", string.Empty),
                    BetType = RefData.GetBetTypeName(ticket.BetTypeId.ToString(), "en", string.Empty),
                    Choice = FDBuildChoice(ticket),
                    CustName = ticket.UserName,
                    IP = ticket.IP,
                    Stake = string.Format("{0:#,##0}", ticket.Stake),
                    WinLoss = ticket.Winlost,
                    Score = string.Format("{0} - {1}", ticket.LiveHomeScore, ticket.LiveAwayScore),
                    Status = ticket.Status,
                    TransDate = ticket.TransDate.ToString(),
                    TransId = ticket.TransId
                };

                if (ticket.OddsType != string.Empty)
                {
                    string oddType = RefData.GetOddsTypeName(ticket.OddsType, "en", string.Empty);
                    item.Odds = string.Format("{0} ({1})", string.Format("{0:#,##0.00}", ticket.Odds), oddType);
                }
                else
                {
                    item.Odds = string.Format("{0:#,##0.00}", ticket.Odds);
                }

                list.Add(item);
            }

            var groupedList = list.Where(x => x.BetType == bettype)
                .GroupBy(y => y.BetType).ToList();
            foreach (var item in groupedList)
            {
                FraudCaseDetailByBetTypeList listDetail = new FraudCaseDetailByBetTypeList()
                {
                    Bettype = item.Key,
                    FraudCaseDetailList = item
                };
                result.Add(listDetail);
            }

            return result;
        }

        private string FDBuildChoice(Ticket ticket)
        {
            string result = string.Empty;
            switch (ticket.BetTypeId)
            {
                case 2:
                case 12:
                case 184:
                    result = ticket.BetTeam.ToUpper() == "H" ? "Odd " : "Even ";
                    break;
                case 3:
                case 8:
                case 18:
                    result = ticket.BetTeam.ToUpper() == "H" ? "Over " + ticket.Handicap1.ToString("0.##") : "Under " + ticket.Handicap1.ToString("0.##");
                    break;
                default:
                    result = ticket.BetTeam.ToUpper() == "H" ?
                        RefData.GetTeamName(ticket.HomeId.ToString(), "en", string.Empty) + " " + string.Format("{0:0.##}", ticket.Handicap2 - ticket.Handicap1)
                        : RefData.GetTeamName(ticket.AwayId.ToString(), "en", string.Empty) + " " + string.Format("{0:0.##}", ticket.Handicap1 - ticket.Handicap2);
                    break;
            }

            return result;
        }

        private FraudCaseDetailSummary GetFraudCaseDetailSummary(FraudCaseDetailReportCriteria criteria)
        {
            var summaryCriteria = new FraudCaseDetailSummaryGetByMatchIdCriteria
            {
                CaseId = criteria.CaseId,
                MatchId = criteria.MatchId,
                TransList = null,
                CaseName = null
            };

            ExecuteOutput(summaryCriteria);

            return new FraudCaseDetailSummary
            {
                MatchId = criteria.MatchId,
                CaseId = criteria.CaseId,
                EventDate = criteria.EventDate,
                CustomerCount = summaryCriteria.CustomerCount,
                BetCount = summaryCriteria.BetCount,
                TransList = summaryCriteria.TransList,
                CaseName = summaryCriteria.CaseName
            };
        }

        private IList<Ticket> GetSuspiciousTickets(
            FraudCaseDetailReportCriteria criteria,
            MoveBetsBalanceUp moveBetBalanceUp,
            FraudCaseDetailSummary summary)
        {
            if (criteria.EventDate > moveBetBalanceUp.BalanceUpDay)
            {
                var body = GetSuspiciousTicketFromBodb02(criteria, moveBetBalanceUp, summary);

                return body;
            }
            else
            {
                var body = GetSuspiciousTicketsFromBodbArchieve(criteria, summary);

                return body;
            }
        }

        private IList<Ticket> GetSuspiciousTicketFromBodb02(
            FraudCaseDetailReportCriteria criteria,
            MoveBetsBalanceUp moveBetBalanceUp,
            FraudCaseDetailSummary summary)
        {
            var newCriteria = new BetTicketGetByTransListCriteria
            {
                MatchId = criteria.MatchId,
                TransList = summary.TransList,
                MoveBetsDay = moveBetBalanceUp.MoveBetsDay,
                EventDate = criteria.EventDate
            };

            var body = GetDataOutput<Ticket>(newCriteria).ToList();
            summary.HomeId = newCriteria.HomeId;
            summary.AwayId = newCriteria.AwayId;
            summary.HTHomeScore = newCriteria.HTHomeScore;
            summary.HTAwayScore = newCriteria.HTAwayScore;
            summary.FTHomeScore = newCriteria.FTHomeScore;
            summary.FTAwayScore = newCriteria.FTAwayScore;

            return body;
        }

        private IList<Ticket> GetSuspiciousTicketsFromBodbArchieve(FraudCaseDetailReportCriteria criteria, FraudCaseDetailSummary summary)
        {
            var newCriteria = new BetTicketGetByTransListFromDbArchiveCriteria
            {
                MatchId = criteria.MatchId,
                TransList = summary.TransList
            };

            var body = GetDataOutput<Ticket>(newCriteria).ToList();
            summary.HomeId = newCriteria.HomeId;
            summary.AwayId = newCriteria.AwayId;
            summary.HTHomeScore = newCriteria.HTHomeScore;
            summary.HTAwayScore = newCriteria.HTAwayScore;
            summary.FTHomeScore = newCriteria.FTHomeScore;
            summary.FTAwayScore = newCriteria.FTAwayScore;

            return body;
        }
    }
}