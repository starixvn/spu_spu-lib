namespace FD.Lib.Criteria.MessageMaster
{
    using Fanex.Data.Repository;

    public class MessageMasterGetAllCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "FD_MessageMasterGetAll";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
