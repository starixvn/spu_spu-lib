namespace FD.Lib.Criteria.Reports.LiveMatchMonitoring
{
    using Fanex.Data.Repository;

    public class LiveMatchMonitoringReportUpdateVerifiedCriteria : CriteriaBase
    {
        public int MatchId { get; set; }

        public bool IsVerified { get; set; }

        public string VerifiedBy { get; set; }

        public override string GetSettingKey()
        {
            return "FD_LiveMatchMonitoringReportUpdateVerified";
        }

        public override bool IsValid()
        {
            return MatchId > 0;
        }
    }
}
