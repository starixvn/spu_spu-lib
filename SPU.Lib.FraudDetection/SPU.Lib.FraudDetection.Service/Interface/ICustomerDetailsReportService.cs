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
    using Criteria.Reports.CustomerDetails;
    using DTO.CustomerDetails;
    using Fanex.Data.Repository;
    using Model.Reports.CustomerDetails;
    using Model.Reports.FraudCaseDetail;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    /// Customer Details interface.
    /// </summary>
    public interface ICustomerDetailsReportService
    {
        CustomerDetailsModel GetCustomerDetailsModel(int custId, DateTime fromDate, DateTime toDate);

        CustomerInfo GetCustomerInfo(ICriteria criteria);

        string GetTransListByCustId(CustomerDetailsReportTransListCriteria criteria);

        IEnumerable<FraudCaseDetails> GetFraudCasesDetails(ICriteria criteria);

        IEnumerable<LogsNotes> GetLogsNotes(ICriteria criteria);

        WinlossStatisticSummary GetWinlossStatisticSummary(ICriteria criteria);

        IEnumerable<WinlossStatisticEventChoice> GetEventChoice(ICriteria criteria);

        IEnumerable<WinlossStatisticTopSports> GetTopSportsByMargin(ICriteria criteria);

        IEnumerable<WinlossStatisticTopBettypes> GetTopBettypeByMargin(ICriteria criteria);

        IEnumerable<FraudCaseDetailItem> GetFraudTickets(int custId, DateTime fromDate, DateTime toDate);

        ICommandResult InsertCustomerLog(ICriteria criteria);

        ICommandResult InsertCustomerNote(ICriteria criteria);

        List<int> GetViolatedCases(ICriteria criteria);
    }
}