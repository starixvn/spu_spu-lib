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
        /// <returns>Fraud Case Detail Report Model.</returns>
        public FraudCaseDetailReportViewModel GetFraudCaseDetails(FraudCaseDetailReportCriteria criteria)
        {
            var moveBetBalanceUp = _balanceUpService.GetBalanceUpDay(new BalanceUpDaySelectCriteria());

            var summary = GetFraudCaseDetailSummary(criteria);

            var suspiciousTickets = GetSuspiciousTickets(criteria, moveBetBalanceUp, summary);

            var list = GetChoiceForSuspiciousTickets(suspiciousTickets);

            return new FraudCaseDetailReportViewModel
            {
                Summary = summary,
                Body = list
            };
        }

        private List<FraudCaseDetailItem> GetChoiceForSuspiciousTickets(IList<Ticket> suspiciousTickets)
        {
            var builder = new BetListHTMLBuilder();
            var ticketHelper = new TicketHelper();

            var list = new List<FraudCaseDetailItem>();

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

            list = list.OrderBy(t => t.CustName).ToList();

            return list;
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
                CustomerCount = summaryCriteria.CustomerCount,
                BetCount = summaryCriteria.BetCount,
                TransList = summaryCriteria.TransList,
                CaseName = summaryCriteria.CaseName
            };
        }

        private IList<Ticket> GetSuspiciousTicketFromBodb02(FraudCaseDetailReportCriteria criteria, MoveBetsBalanceUp moveBetBalanceUp,
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

            return body;
        }

        private IList<Ticket> GetSuspiciousTickets(FraudCaseDetailReportCriteria criteria, MoveBetsBalanceUp moveBetBalanceUp,
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

            return body;
        }
    }
}