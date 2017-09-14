namespace FD.Lib.Criteria.Group
{
    using Fanex.Data.Repository;

    public class GroupGetMemberByIdCriteria : CriteriaBase
    {
        public int GroupId { get; set; }

        public override string GetSettingKey()
        {
            return "FD_GroupMemberGetById";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}