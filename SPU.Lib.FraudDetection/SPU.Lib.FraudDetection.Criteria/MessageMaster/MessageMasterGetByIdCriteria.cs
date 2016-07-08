namespace FD.Lib.Criteria.MessageMaster
{
    using Fanex.Data.Repository;

    public class MessageMasterGetByIdCriteria : CriteriaBase
    {
        public int MessageId { get; set; }

        public override string GetSettingKey()
        {
            return "FD_MessageMasterGetById";
        }

        public override bool IsValid()
        {
            return MessageId > 0;
        }
    }
}
