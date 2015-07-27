namespace SPU.Lib.FraudDetection.Criteria.CaseGroup
{
    using Fanex.Data.Repository;

    public class CaseGroupInsertCriteria : CriteriaBase
    {
        public int CaseId { get; set; }

        public string GroupIds { get; set; }
        
        public override string GetSettingKey()
        {
            return "FD_CaseGroupInsert";
        }
        
        public override bool IsValid()
        {
            return CaseId > 0 && !string.IsNullOrEmpty(GroupIds);
        }
    }
}