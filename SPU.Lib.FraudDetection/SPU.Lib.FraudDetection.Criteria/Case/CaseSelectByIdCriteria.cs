
namespace SPU.Lib.FraudDetection.Criteria.Case
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     CaseSelectAllCriteria Class.
    /// </summary>
    public class CaseSelectByIdCriteria : CriteriaBase
    {
        public int CaseId { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "SPU_CaseSelectById";
        }

        /// <summary>
        ///     Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}
