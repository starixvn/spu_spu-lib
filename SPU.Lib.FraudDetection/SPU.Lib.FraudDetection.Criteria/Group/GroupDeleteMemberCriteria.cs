namespace FD.Lib.Criteria.Group
{
    using Fanex.Data.Repository;

    public class GroupDeleteMemberCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public int GroupId { get; set; }

        public int CustId { get; set; }

        public override string GetSettingKey()
        {
            return "FD_GroupMemberDelete";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
