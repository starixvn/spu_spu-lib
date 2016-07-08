namespace FD.Lib.Criteria.MailMaster
{
    using Fanex.Data.Repository;

    public class MessageMasterUpdateStatusCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public int MessageId { get; set; }

        public bool IsActive { get; set; }

        public int ErrCode { get; set; }

        public string ErrMsg { get; set; }

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
