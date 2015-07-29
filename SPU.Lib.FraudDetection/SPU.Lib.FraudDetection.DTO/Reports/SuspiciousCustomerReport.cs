// --------------------------------------------------------------------------
// <copyright file="SuspiciousCustomerReport.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.24">Created</change>
// </history>

namespace FD.Lib.DTO.Reports
{
    using System.Collections.Generic;

    /// <summary>
    /// The class SuspiciousCustomerReport.
    /// </summary>
    public class SuspiciousCustomerReport
    {
        public SuspiciousCustomerReport()
        {
            Margins = new List<decimal?>();

            WinLoss = new List<decimal?>();
        }

        public Customer Customer { get; set; }

        public Group Group { get; set; }

        public int SuspiciousTime { get; set; }

        public IList<decimal?> Margins { get; set; }

        public IList<decimal?> WinLoss { get; set; }
    }
}
