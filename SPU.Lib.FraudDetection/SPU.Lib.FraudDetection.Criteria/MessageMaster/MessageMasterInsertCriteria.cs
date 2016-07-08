namespace FD.Lib.Criteria.MessageMaster
{
    using Fanex.Data.Repository;

    public class MessageMasterInsertCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public int MessageId { get; set; }

        public string MessageCode { get; set; }

        public string MessageDesc { get; set; }

        public string MessageContent { get; set; }

        public string Recipient { get; set; }

        public string OnlineRecipient { get; set; }

        public bool IsActive { get; set; }

        public override string GetSettingKey()
        {
            return "FD_MessageMasterInsert";
        }

        public override bool IsValid()
        {
            return MessageId > 0;
        }
    }
}
