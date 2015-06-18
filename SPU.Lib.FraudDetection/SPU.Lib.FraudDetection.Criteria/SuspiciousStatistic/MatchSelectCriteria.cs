using Fanex.Data.Repository;

namespace SPU.Lib.FraudDetection.Criteria.SuspiciousStatistic
{
    public class MatchSelectCriteria : CriteriaBase
    {
        public string ListMatchIds { get; set; }

        [SpParam(Ignored = true)]
        public bool IsDbArchieve { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            if (IsDbArchieve)
            {
                return "SPU_SelectMatchInfoFromDB02_Archive";
            }

            return "SPU_SelectMatchInfoFromDB02";
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
