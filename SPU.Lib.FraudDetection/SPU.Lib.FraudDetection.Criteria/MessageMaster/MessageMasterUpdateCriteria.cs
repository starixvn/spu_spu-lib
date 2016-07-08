namespace FD.Lib.Criteria.MessageMaster
{
    using Fanex.Data.Repository;

    public class MessageMasterUpdateCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public int MessageId { get; set; }

        public string MessageCode { get; set; }

        public string MessageDesc { get; set; }

        public string MessageContent { get; set; }

        public string Recipient { get; set; }

        public string OnlineRecipient { get; set; }

        public bool IsActive { get; set; }

        public int ErrCode { get; set; }

        public string ErrMsg { get; set; }

        public override string GetSettingKey()
        {
            return "FD_MessageMasterUpdate";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
