namespace FD.Lib.Criteria.SuspiciousInfo
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     SuspiciousCustomer Class.
    /// </summary>
    public class SuspiciousCustomerInsertCriteria : CriteriaBase
    {
        public string SuspiciousDoc { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_SuspiciousCustomerInsert";
        }

        /// <summary>
        ///     Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(SuspiciousDoc);
        }
    }
}