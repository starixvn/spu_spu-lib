namespace FD.Lib.Criteria.MessageMaster
{
    using Fanex.Data.Repository;

    public class MessageMasterGetAllCriteria : CriteriaBase
    {
        public string Content { get; set; }

        public override string GetSettingKey()
        {
            return "";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
