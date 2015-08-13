namespace FD.Lib.Service.Implement
{
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.Reports;
    using Fanex.BetList.Core.Builder;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.TicketHelper;
    using Fanex.Data;
    using Interface;
    using Model.Reports.FraudCaseDetail;
    using Model.Reports.SuspiciousCustomer;
    using RemotingRef;

    /// <summary>
    /// Fraud Case Detail Report Service.
    /// </summary>
    public class FraudCaseDetailReportService : QueryService, IFraudCaseDetailReportService
    {
        /// <summary>
        /// Get Fraud Case Details.
        /// </summary>
        /// <param name="criteria">Criteria input.</param>
        /// <returns>Fraud Case Detail Report Model.</returns>
        public FraudCaseDetailReportViewModel GetFraudCaseDetails(FraudCaseDetailReportCriteria criteria)
        {
            using (ObjectDb db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var multi = db.QueryMultiple(criteria.GetSpParams()))
                {
                    var summary = multi.Read<FraudCaseDetailSummary>();
                    var body = multi.Read<Ticket>().ToList();

                    var builder = new BetListHTMLBuilder();
                    var ticketHelper = new TicketHelper();

                    var list = new List<FraudCaseDetailItem>();

                    foreach (var ticket in body)
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

                    return new FraudCaseDetailReportViewModel
                    {
                        Summary = summary.SingleOrDefault(),
                        Body = list
                    };
                }
            }
        }
    }
}