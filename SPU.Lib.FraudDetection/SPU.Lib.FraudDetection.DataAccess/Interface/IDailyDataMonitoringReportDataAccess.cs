// --------------------------------------------------------------------------
// <copyright file="IDailyDataMonitoringReportDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.08.12">Created</change>
// </history>

namespace FD.Lib.DataAccess.Interface
{
    using System.Collections.Generic;
    using Criteria.Reports;
    using DTO;

    /// <summary>
    /// Daily Data Monitoring Report Data Access interface.
    /// </summary>
    public interface IDailyDataMonitoringReportDataAccess
    {
        List<MatchMonitoring> GetDailyDataMonitoringReport(DailyDataMonitoringReportGetAllCriteria criteria);
    }
}