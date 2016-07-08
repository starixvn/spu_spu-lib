namespace FD.Lib.Criteria.MessageMaster
{
    using Fanex.Data.Repository;

    public class MessageMasterUpdateStatusCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public int MessageId { get; set; }

        public bool IsActive { get; set; }

        public override string GetSettingKey()
        {
            return "FD_MessageMasterUpdateStatus";
        }

        public override bool IsValid()
        {
            return MessageId > 0;
        }
    }
}
