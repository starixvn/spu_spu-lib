namespace FD.Lib.Criteria.SuspiciousInfo
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     SuspiciousInfo Class.
    /// </summary>
    public class SuspiciousGroupInfoInsertCriteria : CriteriaBase
    {
        public string SuspiciousDoc { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_SuspiciousGroupInfoInsert";
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