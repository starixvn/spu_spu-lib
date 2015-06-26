// --------------------------------------------------------------------------
// <copyright file="CustomerReportDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.11">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Implement
{
    using System.Collections.Generic;
    using DTO;
    using DTO.Reports;
    using Fanex.Data;
    using Fanex.Data.Repository;
    using Interface;

    /// <summary>
    /// Customer Report Data Access.
    /// </summary>
    public class CustomerReportDataAccess : BaseDataAccess, ICustomerReportDataAccess
    {
        /// <summary>
        /// Get all suspicious customers.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>List off suspicious customers.</returns>
        public IEnumerable<SuspiciousCustomerReport> GetSuspiciousCustomersByGroup(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                var suspiciousCustomers = db.Query<SuspiciousCustomerReport, Customer, Group, SuspiciousCustomerReport>(
                    (report, cust, group) =>
                    {
                        report.Customer = cust;
                        report.Group = group;

                        return report;
                    },
                    "CustId,GroupId",
                    criteria.GetSpParams());

                return suspiciousCustomers;
            }
        }
    }
}
