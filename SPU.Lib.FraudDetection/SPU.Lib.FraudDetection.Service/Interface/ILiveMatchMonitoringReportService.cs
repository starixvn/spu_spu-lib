namespace FD.Lib.Service.Interface
{
    using Fanex.Data.Repository;
    using FD.Lib.Criteria.Reports.LiveMatchMonitoring;
    using FD.Lib.DTO;
    using System.Collections.Generic;

    public interface ILiveMatchMonitoringReportService
    {
        IEnumerable<League> GetLeaguesByDate(ICriteria criteria);
        IEnumerable<League> GetLeaguesByDateAndSport(ICriteria criteria);
        List<LiveMatchMonitoring> GetMatchMonitoringReport(LiveMatchMonitoringReportGetAllCriteria criteria);
    }
}
