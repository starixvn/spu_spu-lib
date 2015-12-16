// --------------------------------------------------------------------------
// <copyright file="FraudCaseDetails.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.12.14">Created</change>
// </history>

namespace FD.Lib.DTO.CustomerDetails
{
    using System;

    public class FraudCaseDetails
    {
        public int CaseId { get; set; }

        public string CaseName { get; set; }

        public int TotalViolations { get; set; }

        public int VerifiedViolations { get; set; }

        public int UnverifiedViolations { get; set; }

        public DateTime LastVerifiedDate { get; set; }

        public string LastVerifiedBy { get; set; }

        public string LastVerifiedDateString
        {
            get
            {
                return LastVerifiedDate.ToString("MM/dd/yyyy hh:mm tt");
            }
        }
    }
}