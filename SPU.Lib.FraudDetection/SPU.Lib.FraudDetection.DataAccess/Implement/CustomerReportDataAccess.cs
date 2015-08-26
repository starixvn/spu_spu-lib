// --------------------------------------------------------------------------
// <copyright file="CustomerReportDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.11">Created</change>
// </history>

namespace FD.Lib.DataAccess.Implement
{
    using System.Collections.Generic;
    using DTO;
    using Fanex.Data;
    using Fanex.Data.Repository;
    using Interface;
    using Model.Reports.SuspiciousCustomer;

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
        public SuspiciousCustomerReportListModel GetAllSuspiciousCustomers(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                var suspiciousCustomers = db.Query<SuspiciousCustomerReportModel, Customer, Group, SuspiciousCustomerReportModel>(
                    (report, cust, group) =>
                    {
                        report.Customer = cust;
                        report.Group = group;

                        return report;
                    },
                    "CustId,GroupId",
                    criteria.GetSpParams());

                var totalItem = (int)db.GetOuputParams()["rowcount"];

                var result = new SuspiciousCustomerReportListModel
                {
                    SuspiciousCustomers = suspiciousCustomers,
                    TotalItem = totalItem
                };

                return result;
            }
        }
    }
}
