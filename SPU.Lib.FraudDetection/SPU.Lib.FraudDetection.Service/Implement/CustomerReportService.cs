// --------------------------------------------------------------------------
// <copyright file="CustomerReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.11">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System.Collections.Generic;
    using Criteria.Reports;
    using DataAccess.Implement;
    using DTO.Reports;
    using Interface;

    /// <summary>
    /// The class CustomerReportService.
    /// </summary>
    public class CustomerReportService : ICustomerReportService
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
        public IEnumerable<SuspiciousCustomerReport> GetAllSuspiciousCustomerReport(SuspiciousCustomerReportGetAllCriteria criteria)
        {
            var suspiciousCustomers = _reportDataAccess.GetAllSuspiciousCustomerReport(criteria);

            return suspiciousCustomers;
        }
    }
}