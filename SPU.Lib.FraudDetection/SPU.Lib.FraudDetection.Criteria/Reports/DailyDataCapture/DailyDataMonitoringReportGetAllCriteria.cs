// --------------------------------------------------------------------------
// <copyright file="DailyDataMonitoringReportGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
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
    /// DailyDataMonitoringReportGetAllCriteria Class.
    /// </summary>
    public class DailyDataMonitoringReportGetAllCriteria : CriteriaBase
    {
        public DateTime EventDateFrom { get; set; }

        public DateTime EventDateTo { get; set; }

        public DateTime MoveBetDate { get; set; }

        public DateTime BalanceUpDate { get; set; }
        
        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_DailyDataMonitoringReportGetAll";
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
