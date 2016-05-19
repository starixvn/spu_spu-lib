// --------------------------------------------------------------------------
// <copyright file="ICustomerReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.24">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using System.Collections.Generic;
    using Criteria.Reports;
    using DTO;
    using Model.Reports.SuspiciousCustomer;

    public interface ICustomerReportService
    {
        IEnumerable<SuspiciousCustomerReportModel> GetAllSuspiciousCustomers(SuspiciousCustomerReportGetAllCriteria criteria);

        IEnumerable<SuspiciousCustomerReportNoteModel> GetNotes(SuspiciousCustomerReportGetNotesCriteria criteria);
    }
}