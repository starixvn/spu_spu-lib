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
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Criteria.Reports.CustomerDetails;
    using Criteria.Reports.OfficeIPs;
    using Criteria.SuspiciousStatistic;
    using DTO.CustomerDetails;
    using Fanex.BetList.Core.Builder;
    using Fanex.BetList.Core.TicketHelper;
    using Fanex.Data.Repository;
    using Interface;
    using Model.Reports.CustomerDetails;
    using Model.Reports.FraudCaseDetail;
    using RemotingRef;


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
            var suspiciousDetails = GetSuspiciousInfoByCustId(new OfficeIPsReportGetTransListCriteria
            {
                CaseId = caseId,
                FromDate = fromDate,
                ToDate = toDate
            }).ToList();
            var suspiciousTickets = new List<FraudTicketModel>();

            foreach (var susp in suspiciousDetails)
            {
                suspiciousTickets.AddRange(susp.EventDate >= moveBetBalanceUp.BalanceUpDay
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

        private IEnumerable<FraudTicketModel> GetSuspiciousTicketFromBodb02(CustomerDetailsReportFraudTicketsCriteria criteria)
        {
            return GetDataOutput<FraudTicketModel>(criteria).ToList();
        }

        private IEnumerable<FraudTicketModel> GetSuspiciousTicketsFromBodbArchieve(CustomerDetailsReportFraudTicketsFromDbArchiveCriteria criteria)
        {
            return GetDataOutput<FraudTicketModel>(criteria).ToList();
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
                    Score = ticket.LiveHomeScore + " - " + ticket.LiveAwayScore,
                    Status = ticket.Status,
                    TransDate = ticket.TransDate.ToString(CultureInfo.InvariantCulture),
                    TransId = ticket.TransId
                };

                list.Add(item);
            }

            return list.OrderBy(t => t.CustName).ToList();
        }

        private IEnumerable<SuspiciousInfoDetails> GetSuspiciousInfoByCustId(ICriteria criteria)
        {
            return GetData<SuspiciousInfoDetails>(criteria);
        }
    }
}