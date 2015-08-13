namespace FD.Lib.Criteria.Reports
{
    using System;
    using Fanex.Data.Repository;

    public class FraudCaseDetailReportCriteria : CriteriaBase
    {
        public int MatchId { get; set; }

        public int CaseId { get; set; }

        public DateTime EventDate { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_FraudCaseDetailGetByMatchId";
        }

        /// <summary>
        /// Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}
