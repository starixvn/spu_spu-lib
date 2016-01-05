// --------------------------------------------------------------------------
// <copyright file="ICustomerDetailsReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2016.01.05">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using System;
    using System.Collections.Generic;
    using Model.Reports.FraudCaseDetail;

    public interface IOfficeIPsReportService
    {
        IEnumerable<FraudCaseDetailItem> GetFraudTickets(int caseId, DateTime fromDate, DateTime toDate);

        IEnumerable<FraudCaseDetailItem> ExportExcel(int caseId, DateTime fromDate, DateTime toDate);
    }
}