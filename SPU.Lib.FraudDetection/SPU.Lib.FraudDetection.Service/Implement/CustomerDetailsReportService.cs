// --------------------------------------------------------------------------
// <copyright file="ICustomerDetailsReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.12.14">Created</change>
// </history>

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
    using Fanex.BetList.Core.Entities;
    using Fanex.BetList.Core.TicketHelper;
    using Fanex.Data.Repository;
    using Interface;
    using Model.Reports.CustomerDetails;
    using Model.Reports.FraudCaseDetail;
    using RemotingRef;
    using Fanex.NAP.Framework.Command;

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

        public string GetTransListByCustId(CustomerDetailsReportTransListCriteria criteria)
        {
            return _customerDetailsDataAccess.GetTransListByCustId(criteria);
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
            return GetData<WinlossStatisticSummary>(criteria).First(); ;
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
            var transList = _customerDetailsDataAccess.GetTransListByCustId(new CustomerDetailsReportTransListCriteria(custId, fromDate, toDate));
            var suspiciousTickets = toDate < moveBetBalanceUp.BalanceUpDay
                ? GetSuspiciousTicketsFromBodbArchieve(new CustomerDetailsReportFraudTicketsFromDbArchiveCriteria(transList))
                : GetSuspiciousTicketFromBodb02(new CustomerDetailsReportFraudTicketsCriteria(fromDate, toDate, moveBetBalanceUp.MoveBetsDay, transList));

            return GetChoiceForSuspiciousTickets(suspiciousTickets);
        }
        
        public IList<Ticket> GetSuspiciousTicketFromBodb02(CustomerDetailsReportFraudTicketsCriteria criteria)
        {
            return GetDataOutput<Ticket>(criteria).ToList();
        }

        public IList<Ticket> GetSuspiciousTicketsFromBodbArchieve(CustomerDetailsReportFraudTicketsFromDbArchiveCriteria criteria)
        {
            return GetDataOutput<Ticket>(criteria).ToList();
        }

        public IEnumerable<FraudCaseDetailItem> GetChoiceForSuspiciousTickets(IEnumerable<Ticket> suspiciousTickets)
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

        public List<int> GetViolatedCases(ICriteria criteria)
        {
            return _customerDetailsDataAccess.GetViolatedCases(criteria);
        }
    }
}