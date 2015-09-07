// --------------------------------------------------------------------------
// <copyright file="SuspiciousCustomerReportModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.24">Created</change>
// </history>

namespace FD.Lib.Model.Reports.SuspiciousCustomer
{
    using DTO;

    /// <summary>
    /// The class SuspiciousCustomerReport.
    /// </summary>
    public class SuspiciousCustomerReportModel
    {
        public int Row { get; set; }

        public Customer Customer { get; set; }

        public Group Group { get; set; }

        public int SuspiciousTime { get; set; }
    }
}
