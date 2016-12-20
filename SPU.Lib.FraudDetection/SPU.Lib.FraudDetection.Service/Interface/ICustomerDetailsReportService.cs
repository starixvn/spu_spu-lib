// --------------------------------------------------------------------------
// <copyright file="ICustomerDetailsReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.12.14">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using System;
    using System.Collections.Generic;
    using DTO.CustomerDetails;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Model.Reports.CustomerDetails;
    using Model.Reports.FraudCaseDetail;

    /// <summary>
    /// Customer Details interface.
    /// </summary>
    public interface ICustomerDetailsReportService
    {
        CustomerDetailsModel GetCustomerDetailsModel(int custId, DateTime fromDate, DateTime toDate, bool isTest);

        CustomerInfo GetCustomerInfo(ICriteria criteria);

        IEnumerable<SuspiciousInfoDetails> GetSuspiciousInfoByCustId(ICriteria criteria);

        IEnumerable<FraudCaseDetails> GetFraudCasesDetails(ICriteria criteria);

        IEnumerable<LogsNotes> GetLogsNotes(ICriteria criteria);

        ICommandResult RemoveCustomerLogNote(ICriteria criteria);

        WinlossStatisticSummary GetWinlossStatisticSummary(ICriteria criteria);

        IEnumerable<WinlossStatisticEventChoice> GetEventChoice(ICriteria criteria);

        IEnumerable<WinlossStatisticTopSports> GetTopSportsByMargin(ICriteria criteria);

        IEnumerable<WinlossStatisticTopBettypes> GetTopBettypeByMargin(ICriteria criteria);

        IEnumerable<FraudCaseDetailItem> GetFraudTickets(int custId, DateTime fromDate, DateTime toDate, bool isTest);

        ICommandResult InsertCustomerLog(ICriteria criteria);

        ICommandResult InsertCustomerNote(ICriteria criteria);

        ICommandResult UpdateCustomerDelinquent(ICriteria criteria);

        ICommandResult UpdateCustomerHedge(ICriteria criteria);

        List<int> GetViolatedCases(ICriteria criteria);

        ICommandResult InsertAssignees(ICriteria criteria);

        string GetAssignees(ICriteria criteria);

        IEnumerable<MarginModel> GetMonthlyWinloss(ICriteria criteria);

        FraudCaseDetailBetListViewModel GetFraudTicketsByIp(string ip);
    }
}