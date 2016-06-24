namespace FD.Lib.DataAccess.Interface
{
    using FD.Lib.Criteria.Reports.LiveMatchMonitoring;
    using FD.Lib.DTO;
    using System.Collections.Generic;

    public interface ILiveMatchMonitoringReportDataAccess
    {
        List<LiveMatchMonitoring> GetMatchMonitoringReport(LiveMatchMonitoringReportGetAllCriteria criteria);
    }
}
