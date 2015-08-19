// --------------------------------------------------------------------------
// <copyright file="IMatchMonitoringReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.08.12">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using System.Collections.Generic;
    using DTO;
    using Fanex.Data.Repository;
    using Criteria.Reports;

    /// <summary>
    /// Match Monitoring interface.
    /// </summary>
    public interface IMatchMonitoringReportService
    {
        IEnumerable<League> GetLeaguesByDate(ICriteria criteria);

        List<MatchMonitoring> GetMatchMonitoringReport(MatchMonitoringReportGetAllCriteria criteria);

        List<MatchMonitoring> GetMatchMonitoringReportFromDBArchive(MatchMonitoringReportGetAllDBArchiveCriteria criteria);
    }
}