// --------------------------------------------------------------------------
// <copyright file="OfficeIPsReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2016.01.05">Created</change>
// </history>

namespace FD.Lib.Service.Implement
{
    using Criteria.Reports.CustomerDetails;
    using Criteria.Reports.OfficeIPs;
    using Criteria.SuspiciousStatistic;
    using DTO.CustomerDetails;
    using Fanex.BetList.Core.Builder;
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.TicketHelper;
    using Fanex.Data.Repository;
    using Interface;
    using Model.Reports.CustomerDetails;
    using Model.Reports.FraudCaseDetail;
    using RemotingRef;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class OfficeIPsReportService : QueryService, IOfficeIPsReportService
    {
        private readonly IMoveBetsBalanceUpService _balanceUpService;

        public OfficeIPsReportService()
        {
            _balanceUpService = new MoveBetsBalanceUpService();
        }

        public IEnumerable<FraudCaseDetailItem> GetFraudTickets(int caseId, DateTime fromDate, DateTime toDate)
        {
            var moveBetBalanceUp = _balanceUpService.GetBalanceUpDay(new BalanceUpDaySelectCriteria());
            var suspiciousDetails = GetSuspiciousInfoByCaseId(new OfficeIPsReportGetTransListCriteria
            {
                CaseId = caseId,
                FromDate = fromDate,
                ToDate = toDate
            }).ToList();

            var suspiciousDetailDistinct = DistinctSuspiciousDetails(suspiciousDetails);

            var suspiciousTickets = new List<FraudTicketModel>();

            foreach (var susp in suspiciousDetailDistinct)
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

        public IEnumerable<FraudCaseDetailItem> ExportExcel(int caseId, DateTime fromDate, DateTime toDate)
        {
            var moveBetBalanceUp = _balanceUpService.GetBalanceUpDay(new BalanceUpDaySelectCriteria());
            var suspiciousDetails = GetSuspiciousInfoByCaseId(new OfficeIPsReportGetTransListCriteria
            {
                CaseId = caseId,
                FromDate = fromDate,
                ToDate = toDate
            }).ToList();

            var suspiciousDetailDistinct = DistinctSuspiciousDetails(suspiciousDetails);

            var suspiciousTickets = new List<FraudTicketModel>();

            foreach (var susp in suspiciousDetailDistinct)
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

            return GetDataForExportExcel(suspiciousTickets);
        }

        private IEnumerable<FraudTicketModel> GetSuspiciousTicketFromBodb02(CustomerDetailsReportFraudTicketsCriteria criteria)
        {
            return GetDataOutput<FraudTicketModel>(criteria).ToList();
        }

        private IEnumerable<FraudTicketModel> GetSuspiciousTicketsFromBodbArchieve(CustomerDetailsReportFraudTicketsFromDbArchiveCriteria criteria)
        {
            return GetDataOutput<FraudTicketModel>(criteria).ToList();
        }

        private IEnumerable<FraudCaseDetailItem> GetDataForExportExcel(IEnumerable<FraudTicketModel> suspiciousTickets)
        {
            var list = new List<FraudCaseDetailItem>();

            foreach (var ticket in suspiciousTickets)
            {
                var item = new FraudCaseDetailItem
                {
                    BetType = RefData.GetBetTypeName(ticket.BetTypeId.ToString(), "en", string.Empty),
                    Choice = FDBuildChoice(ticket),
                    CustName = ticket.UserName,
                    IP = ticket.IP,
                    Odds = string.Format("{0} ({1})", string.Format("{0:#,##0.00}", ticket.Odds), RefData.GetOddsTypeName(ticket.OddsType, "en", string.Empty)),
                    Stake = string.Format("{0:#,##0}", ticket.Stake),
                    WinLoss = ticket.Winlost,
                    Score = string.Format("{0} - {1}", ticket.LiveHomeScore, ticket.LiveAwayScore),
                    Status = ticket.Status,
                    TransDate = ticket.TransDate.ToString(CultureInfo.InvariantCulture),
                    TransId = ticket.TransId
                };

                list.Add(item);
            }

            return list.OrderBy(t => t.CustName).ToList();
        }

        private IEnumerable<FraudCaseDetailItem> GetChoiceForSuspiciousTickets(IEnumerable<FraudTicketModel> suspiciousTickets)
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
                    Score = string.Format("{0} - {1}", ticket.LiveHomeScore, ticket.LiveAwayScore),
                    Status = ticket.Status,
                    TransDate = ticket.TransDate.ToString(CultureInfo.InvariantCulture),
                    TransId = ticket.TransId
                };

                list.Add(item);
            }

            return list.OrderBy(t => t.CustName).ToList();
        }

        private IEnumerable<SuspiciousInfoDetails> GetSuspiciousInfoByCaseId(ICriteria criteria)
        {
            return GetData<SuspiciousInfoDetails>(criteria);
        }

        private string FDBuildChoice(ITicket ticket)
        {
            return ticket.BetTeam.ToUpper() == "H"
                ? RefData.GetTeamName(
                ticket.HomeId.ToString(CultureInfo.InvariantCulture), "en", string.Empty) + " " + string.Format("{0:0.##}", ticket.Handicap2 - ticket.Handicap1)
                : RefData.GetTeamName(
                ticket.AwayId.ToString(CultureInfo.InvariantCulture), "en", string.Empty) + " " + string.Format("{0:0.##}", ticket.Handicap1 - ticket.Handicap2);
        }

        private IEnumerable<SuspiciousInfoDetails> DistinctSuspiciousDetails(IEnumerable<SuspiciousInfoDetails> suspiciousDetails)
        {
            var result = new List<SuspiciousInfoDetails>();
            var matchIds = suspiciousDetails.Select(x => x.MatchId).Distinct();

            foreach (var matchId in matchIds)
            {
                var id = matchId;
                var suspiciousInfoDetail = new SuspiciousInfoDetails
                {
                    MatchId = matchId,
                    EventDate = suspiciousDetails.FirstOrDefault(x => x.MatchId == matchId).EventDate,
                    TransList = string.Join(",", suspiciousDetails.Where(x => x.MatchId == id).Select(m => m.TransList))
                };

                result.Add(suspiciousInfoDetail);
            }

            return result;
        }
    }
}