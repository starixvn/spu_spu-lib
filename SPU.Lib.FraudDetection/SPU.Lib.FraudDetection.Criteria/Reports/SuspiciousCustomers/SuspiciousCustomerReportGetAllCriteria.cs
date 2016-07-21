// --------------------------------------------------------------------------
// <copyright file="SuspiciousCustomerReportGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.24">Created</change>
//   <change who="Aaron.Cao" date="2015.08.25">Modified</change>
// </history>

namespace FD.Lib.Criteria.Reports
{
    using System;
    using Fanex.Data.Repository;

    /// <summary>
    /// SuspiciousCustomerReportGetAllCriteria Class.
    /// </summary>
    public class SuspiciousCustomerReportGetAllCriteria : CriteriaBase
    {
        public DateTime EventDateFrom { get; set; }

        public DateTime EventDateTo { get; set; }

        public string CustName { get; set; }

        public bool? IsVerified { get; set; }

        public int? CaseId { get; set; }

        public bool? IsDelinquent { get; set; }

        public bool? IsHedge { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_SuspiciousCustomerReportGetAll";
        }

        /// <summary>
        /// Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}
