// --------------------------------------------------------------------------
// <copyright file="MatchMonitoringReportUpdateVerifiedCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.12.29">Created</change>
// </history>

namespace FD.Lib.Criteria.Reports
{
    using Fanex.Data.Repository;

    /// <summary>
    /// MatchMonitoringReportUpdateVerifiedCriteria Class.
    /// </summary>
    public class MatchMonitoringReportUpdateVerifiedCriteria : CriteriaBase
    {
        public int MatchId { get; set; }

        public bool IsVerified { get; set; }

        public string VerifiedBy { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_MatchMonitoringReportUpdateVerified";
        }

        /// <summary>
        /// Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return MatchId > 0;
        }
    }
}
