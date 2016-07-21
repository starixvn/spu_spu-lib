namespace FD.Lib.Criteria.Reports
{
    using Fanex.Data.Repository;

    public class SumWinLossByTransIdsGetFromDbArchiveCriteria : CriteriaBase
    {
        public string TransList { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_SumWinLossByTransIdsGetFromDBArchive";
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
