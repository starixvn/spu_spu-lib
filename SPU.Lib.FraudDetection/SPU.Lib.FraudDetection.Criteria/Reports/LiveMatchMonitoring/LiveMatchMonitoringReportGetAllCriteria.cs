namespace FD.Lib.Criteria.Reports.LiveMatchMonitoring
{
    using Fanex.Data.Repository;
    using System;

    public class LiveMatchMonitoringReportGetAllCriteria : CriteriaBase
    {
        public DateTime EventDate { get; set; }

        public string LeagueIds { get; set; }

        [SpParam(Ignored = true)]
        public int LeagueId { get; set; }

        public string MatchCode { get; set; }

        public bool? IsMainMarket { get; set; }

        public bool IsTest { get; set; }

        // Out put param
        public int NumberOfCases { get; set; }

        public override string GetSettingKey()
        {
            return "FD_LiveMatchMonitoringReportGetAll";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
