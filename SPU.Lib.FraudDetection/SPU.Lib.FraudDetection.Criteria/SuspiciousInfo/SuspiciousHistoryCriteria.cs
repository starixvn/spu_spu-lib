namespace SPU.Lib.FraudDetection.Criteria.SuspiciousInfo
{
    using Fanex.Data.Repository;

    public class SuspiciousHistoryCriteria : CriteriaBase
    {
        public string CustIdList { get; set; }
        public int CaseId { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "SPU_SuspiciouCustomerSelect";
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