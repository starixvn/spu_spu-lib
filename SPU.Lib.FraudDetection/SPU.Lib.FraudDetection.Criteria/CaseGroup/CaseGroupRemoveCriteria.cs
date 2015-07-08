namespace SPU.Lib.FraudDetection.Criteria.CaseGroup
{
    using Fanex.Data.Repository;

    public class CaseGroupRemoveCriteria : CriteriaBase
    {
        public int CaseId { get; set; }

        public int GroupId { get; set; }

        public override string GetSettingKey()
        {
            return "SPU_CaseGroupDel";
        }

        public override bool IsValid()
        {
            return CaseId > 0 && GroupId > 0;
        }
    }
}