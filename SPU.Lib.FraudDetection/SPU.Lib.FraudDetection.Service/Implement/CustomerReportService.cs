// --------------------------------------------------------------------------
// <copyright file="CustomerReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------

using System.Collections.Generic;

namespace FD.Lib.Service.Implement
{
    using Criteria.Reports;
    using DataAccess.Implement;
    using Interface;
    using Model.Reports.SuspiciousCustomer;

    /// <summary>
    /// The class CustomerReportService.
    /// </summary>
    public class CustomerReportService : QueryService, ICustomerReportService
    {
        private readonly CustomerReportDataAccess _reportDataAccess;

        public CustomerReportService()
        {
            _reportDataAccess = new CustomerReportDataAccess();
        }

        /// <summary>
        /// Get all Suspicious Customers.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>The list of Suspicious Customers.</returns>
        public SuspiciousCustomerReportListModel GetAllSuspiciousCustomers(SuspiciousCustomerReportGetAllCriteria criteria)
        {
            var suspiciousCustomers = _reportDataAccess.GetAllSuspiciousCustomers(criteria);

            return suspiciousCustomers;
        }

        public IEnumerable<SuspiciousCustomerReportNoteModel> GetNotes(SuspiciousCustomerReportGetNotesCriteria criteria)
        {
            return GetData<SuspiciousCustomerReportNoteModel>(criteria);
        }
    }
}