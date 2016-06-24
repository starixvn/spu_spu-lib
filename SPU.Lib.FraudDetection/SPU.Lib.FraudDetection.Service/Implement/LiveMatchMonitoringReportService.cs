namespace FD.Lib.Service.Implement
{
    using Fanex.Data.Repository;
    using FD.Lib.Criteria.Common;
    using FD.Lib.Criteria.Reports.LiveMatchMonitoring;
    using FD.Lib.DataAccess.Implement;
    using FD.Lib.DataAccess.Interface;
    using FD.Lib.DTO;
    using FD.Lib.Service.Interface;
    using System.Collections.Generic;

    public class LiveMatchMonitoringReportService : QueryService, ILiveMatchMonitoringReportService
    {
        private readonly ILiveMatchMonitoringReportDataAccess matchMonitoringReportDataAccess;

        public LiveMatchMonitoringReportService()
        {
            matchMonitoringReportDataAccess = new LiveMatchMonitoringReportDataAccess();
        }

        public LiveMatchMonitoringReportService(ILiveMatchMonitoringReportDataAccess dataAccess)
        {
            matchMonitoringReportDataAccess = dataAccess;
        }

        public IEnumerable<League> GetLeaguesByDate(ICriteria criteria)
        {
            return GetData<League>(criteria);
        }

        public IEnumerable<League> GetLeaguesByDateAndSport(ICriteria criteria)
        {
            return GetData<League>(criteria);
        }

        public List<LiveMatchMonitoring> GetMatchMonitoringReport(LiveMatchMonitoringReportGetAllCriteria criteria)
        {
            return matchMonitoringReportDataAccess.GetMatchMonitoringReport(criteria);
        }
    }
}
