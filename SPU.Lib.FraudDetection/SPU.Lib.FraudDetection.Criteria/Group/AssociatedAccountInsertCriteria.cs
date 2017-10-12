namespace FD.Lib.Criteria.Group
{
    using Fanex.Data.Repository;

    public class AssociatedAccountInsertCriteria : CriteriaBase
    {
        public string CustNameList { get; set; }

        public int GroupId { get; set; }

        public int CaseId { get; set; }

        public override string GetSettingKey()
        {
            return "FD_AssociatedAccountInsert";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
