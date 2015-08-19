// --------------------------------------------------------------------------
// <copyright file="MatchMonitoringReportService.cs" company="Nexcel Solutions Vietnam">
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
    using Fanex.Data.Repository;
    using Interface;

    /// <summary>
    /// Match Monitoring Service.
    /// </summary>
    public class MatchMonitoringReportService : QueryService, IMatchMonitoringReportService
    {
        private readonly IMatchMonitoringReportDataAccess _matchMonitoringReportDataAccess;

        public MatchMonitoringReportService()
        {
            _matchMonitoringReportDataAccess = new MatchMonitoringReportDataAccess();
        }

        public MatchMonitoringReportService(IMatchMonitoringReportDataAccess dataAccess)
        {
            _matchMonitoringReportDataAccess = dataAccess;
        }

        public IEnumerable<League> GetLeaguesByDate(ICriteria criteria)
        {
            return GetData<League>(criteria);
        }

        public List<MatchMonitoring> GetMatchMonitoringReport(MatchMonitoringReportGetAllCriteria criteria)
        {
            return _matchMonitoringReportDataAccess.GetMatchMonitoringReport(criteria);
        }

        public List<MatchMonitoring> GetMatchMonitoringReportFromDBArchive(
            MatchMonitoringReportGetAllDBArchiveCriteria criteria)
        {
            return _matchMonitoringReportDataAccess.GetMatchMonitoringReportFromDBArchive(criteria);
        }
    }
}