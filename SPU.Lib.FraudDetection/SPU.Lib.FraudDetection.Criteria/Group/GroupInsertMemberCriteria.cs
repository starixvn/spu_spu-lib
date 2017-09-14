namespace FD.Lib.Criteria.Group
{
    using Fanex.Data.Repository;

    public class GroupInsertMemberCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public int GroupId { get; set; }

        public string Username { get; set; }

        public override string GetSettingKey()
        {
            return "FD_GroupMemberInsert";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
