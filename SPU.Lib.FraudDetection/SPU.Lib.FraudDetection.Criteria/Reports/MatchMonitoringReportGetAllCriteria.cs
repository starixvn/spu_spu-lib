// --------------------------------------------------------------------------
// <copyright file="MatchMonitoringReportGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.08.11">Created</change>
// </history>

namespace FD.Lib.Criteria.Reports
{
    using System;
    using Fanex.Data.Repository;

    /// <summary>
    /// MatchMonitoringReportGetAllCriteria Class.
    /// </summary>
    public class MatchMonitoringReportGetAllCriteria : CriteriaBase
    {
        public DateTime EventDate { get; set; }

        public int LeagueId { get; set; }

        public string MatchStatus { get; set; }

        public int SuspiciousStatus { get; set; }

        // Out put param
        public int NumberOfCases { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_MatchMonitoringReportGetAll";
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
