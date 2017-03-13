namespace FD.Lib.Criteria.MessageMaster
{
    using Fanex.Data.Repository;

    public class MessageMasterDeleteCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public int MessageId { get; set; }

        public override string GetSettingKey()
        {
            return "FD_MessageMasterDelete";
        }

        public override bool IsValid()
        {
            return MessageId > 0;
        }
    }
}
