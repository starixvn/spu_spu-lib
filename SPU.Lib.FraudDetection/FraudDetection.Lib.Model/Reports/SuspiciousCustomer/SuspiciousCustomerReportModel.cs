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
    using System;
    using DTO;

    /// <summary>
    /// The class SuspiciousCustomerReport.
    /// </summary>
    public class SuspiciousCustomerReportModel
    {
        public int Row { get; set; }

        public bool IsDelinquent { get; set; }

        public bool HasNote { get; set; }

        public bool IsVerified { get; set; }

        public Customer Customer { get; set; }

        public int TotalViolations { get; set; }

        public int NewViolations { get; set; }

        public int ViolatedCases { get; set; }

        public string Assignees { get; set; }

        public string LastVerifiedDateString
        {
            get
            {
                return LastVerifiedDate.HasValue ? LastVerifiedDate.Value.ToString("MM/dd/yyyy hh:mm:ss tt") : string.Empty;
            }
        }

        public DateTime? LastVerifiedDate { get; set; }

        public string LastVerifiedBy { get; set; }
    }
}
