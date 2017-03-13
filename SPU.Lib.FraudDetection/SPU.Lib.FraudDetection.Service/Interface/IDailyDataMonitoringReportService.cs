// --------------------------------------------------------------------------
// <copyright file="IDailyDataMonitoringReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.08.12">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using Criteria.Reports;
    using DTO;
    using System.Collections.Generic;

    /// <summary>
    /// Daily Data Monitoring interface.
    /// </summary>
    public interface IDailyDataMonitoringReportService
    {
        IEnumerable<DailyDataMonitoring> GetDailyDataMonitoringReport(DailyDataMonitoringReportGetAllCriteria criteria);
    }
}