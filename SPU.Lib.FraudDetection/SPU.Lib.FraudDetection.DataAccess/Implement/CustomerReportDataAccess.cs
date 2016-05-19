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
    using DTO;
    using Fanex.Data;
    using Fanex.Data.Repository;
    using Interface;
    using Model.Reports.SuspiciousCustomer;
    using System.Collections.Generic;

    /// <summary>
    /// Customer Report Data Access.
    /// </summary>
    public class CustomerReportDataAccess : BaseDataAccess, ICustomerReportDataAccess
    {
        public IEnumerable<SuspiciousCustomerReportModel> GetAllSuspiciousCustomers(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                var suspiciousCustomers = db.Query<SuspiciousCustomerReportModel, Customer, SuspiciousCustomerReportModel>(
                    (report, cust) =>
                    {
                        report.Customer = cust;

                        return report;
                    },
                    "CustId",
                    criteria.GetSpParams());

                return suspiciousCustomers;
            }
        }
    }
}
