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
    using Criteria.Reports;
    using Model.Reports.SuspiciousCustomer;

    public interface ICustomerReportService
    {
        SuspiciousCustomerReportListModel GetAllSuspiciousCustomers(SuspiciousCustomerReportGetAllCriteria criteria);
    }
}