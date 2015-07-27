namespace SPU.Lib.FraudDetection.Criteria.CaseGroup
{
    using Fanex.Data.Repository;

    public class CaseGroupDeleteCriteria : CriteriaBase
    {
        public int CaseId { get; set; }

        public int GroupId { get; set; }

        public override string GetSettingKey()
        {
            return "FD_CaseGroupDelete";
        }

        public override bool IsValid()
        {
            return CaseId > 0 && GroupId > 0;
        }
    }
}