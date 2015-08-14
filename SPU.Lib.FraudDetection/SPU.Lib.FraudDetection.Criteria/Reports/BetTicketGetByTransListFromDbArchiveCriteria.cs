namespace FD.Lib.Criteria.Reports
{
    using Fanex.Data.Repository;

    public class BetTicketGetByTransListFromDbArchiveCriteria : CriteriaBase
    {
        public int MatchId { get; set; }

        public string TransList { get; set; }

        public int HomeId { get; set; }

        public int AwayId { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_BetTicketGetByTransListFromDBArchive";
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