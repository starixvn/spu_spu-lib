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
    using Criteria.Reports;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    /// Match Monitoring interface.
    /// </summary>
    public interface IMatchMonitoringReportService
    {
        IEnumerable<League> GetLeaguesByDate(ICriteria criteria);

        IEnumerable<League> GetLeaguesByDateAndSport(ICriteria criteria);

        List<MatchMonitoring> GetMatchMonitoringReport(MatchMonitoringReportGetAllCriteria criteria);

        List<MatchMonitoring> GetMatchMonitoringReportFromDBArchive(MatchMonitoringReportGetAllDBArchiveCriteria criteria);

        ICommandResult UpdateDelinquency(ICriteria criteria);

        ICommandResult UpdateVerification(ICriteria criteria);
    }
}