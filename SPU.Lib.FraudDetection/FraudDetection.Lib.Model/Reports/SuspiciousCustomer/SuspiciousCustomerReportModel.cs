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
    using System.Collections.Generic;
    using DTO;

    /// <summary>
    /// The class SuspiciousCustomerReport.
    /// </summary>
    public class SuspiciousCustomerReportModel
    {
        public SuspiciousCustomerReportModel()
        {
            Margins = new List<decimal?>();

            WinLoss = new List<decimal?>();
        }

        public int Row { get; set; }

        public Customer Customer { get; set; }

        public Group Group { get; set; }

        public int SuspiciousTime { get; set; }

        public IList<decimal?> Margins { get; set; }

        public IList<decimal?> WinLoss { get; set; }
    }
}
