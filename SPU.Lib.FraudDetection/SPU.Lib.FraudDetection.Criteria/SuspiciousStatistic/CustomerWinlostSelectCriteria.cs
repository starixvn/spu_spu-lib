namespace SPU.Lib.FraudDetection.Criteria.SuspiciousStatistic
{
    using System;
    using Fanex.Data.Repository;

    public class CustomerWinlostSelectCriteria : CriteriaBase
    {
        public string ListCustIDs { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "SPU_CustomerWinlostSelect";
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