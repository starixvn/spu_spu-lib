namespace FD.Lib.Criteria.Reports
{
    using System;

    public class FraudCaseDetailReportCriteria
    {
        public int MatchId { get; set; }

        public int CaseId { get; set; }

        public DateTime EventDate { get; set; }
    }
}
