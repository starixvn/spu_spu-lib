// --------------------------------------------------------------------------
// <copyright file="DailyDataMonitoringReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.08.12">Created</change>
// </history>

namespace FD.Lib.Service.Implement
{
    using System.Collections.Generic;
    using Criteria.Reports;
    using DataAccess.Implement;
    using DataAccess.Interface;
    using DTO;
    using Interface;

    /// <summary>
    /// Match Monitoring Service.
    /// </summary>
    public class DailyDataMonitoringReportService : QueryService, IDailyDataMonitoringReportService
    {
        private readonly IDailyDataMonitoringReportDataAccess _dailyDataMonitoringReportDataAccess;

        public DailyDataMonitoringReportService()
        {
            _dailyDataMonitoringReportDataAccess = new DailyDataMonitoringReportDataAccess();
        }

        public DailyDataMonitoringReportService(IDailyDataMonitoringReportDataAccess dataAccess)
        {
            _dailyDataMonitoringReportDataAccess = dataAccess;
        }

        public IEnumerable<DailyDataMonitoring> GetDailyDataMonitoringReport(
            DailyDataMonitoringReportGetAllCriteria criteria)
        {
            //return _dailyDataMonitoringReportDataAccess.GetDailyDataMonitoringReport(criteria);
            return GetData<DailyDataMonitoring>(criteria);
        }
    }
}