namespace FD.Lib.Criteria.SuspiciousStatistic
{
    using Fanex.Data.Repository;

    public class SuspiciousCustomerGetByIdCriteria : CriteriaBase
    {
        public string CustIdList { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_SuspiciousCustomerGetById";
        }

        /// <summary>
        ///     Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(CustIdList);
        }
    }
}