// --------------------------------------------------------------------------
// <copyright file="MatchMonitoringReportGetAllDBArchiveCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.08.18">Created</change>
// </history>

namespace FD.Lib.Criteria.Reports
{
    using System;
    using Fanex.Data.Repository;

    /// <summary>
    /// MatchMonitoringReportGetAllDBArchiveCriteria Class.
    /// </summary>
    public class MatchMonitoringReportGetAllDBArchiveCriteria : CriteriaBase
    {
        public DateTime EventDate { get; set; }

        public int LeagueId { get; set; }

        public string MatchCode { get; set; }

        public string MatchStatus { get; set; }

        public int SuspiciousStatus { get; set; }

        // Out put param
        public int NumberOfCases { get; set; }

        public MatchMonitoringReportGetAllDBArchiveCriteria(MatchMonitoringReportGetAllCriteria criteria)
        {
            EventDate = criteria.EventDate;
            LeagueId = criteria.LeagueId;
            MatchCode = criteria.MatchCode;
            MatchStatus = criteria.MatchStatus;
            SuspiciousStatus = criteria.SuspiciousStatus;
        }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_MatchMonitoringReportGetAll_DBArchive";
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
