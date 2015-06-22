using Fanex.Data.Repository;

namespace SPU.Lib.FraudDetection.Criteria.SuspiciousStatistic
{
    public class BalanceUpDaySelectCriteria : CriteriaBase
    {
        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "SPU_SelBalanceUpDay";
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
