// --------------------------------------------------------------------------
// <copyright file="SuspiciousCustomerReportGetNotesCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.12.09">Created</change>
// </history>

namespace FD.Lib.Criteria.Reports
{
    using Fanex.Data.Repository;

    /// <summary>
    /// SuspiciousCustomerReportGetNotesCriteria Class.
    /// </summary>
    public class SuspiciousCustomerReportGetNotesCriteria : CriteriaBase
    {
        public int CustId { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_SuspiciousCustomerReportGetNotes";
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
