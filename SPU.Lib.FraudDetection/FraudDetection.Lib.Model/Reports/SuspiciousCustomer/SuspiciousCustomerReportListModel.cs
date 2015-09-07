// --------------------------------------------------------------------------
// <copyright file="SuspiciousCustomerReportListModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.08.25">Created</change>
// </history>

namespace FD.Lib.Model.Reports.SuspiciousCustomer
{
    using System.Collections.Generic;

    /// <summary>
    /// The class SuspiciousCustomerReportListModel.
    /// </summary>
    public class SuspiciousCustomerReportListModel
    {
        public SuspiciousCustomerReportListModel()
        {
            SuspiciousCustomers = new List<SuspiciousCustomerReportModel>();
        }

        public int TotalItem { get; set; }

        public IEnumerable<SuspiciousCustomerReportModel> SuspiciousCustomers { get; set; }
    }
}
