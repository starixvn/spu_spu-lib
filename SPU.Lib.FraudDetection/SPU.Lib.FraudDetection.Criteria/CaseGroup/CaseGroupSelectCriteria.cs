namespace SPU.Lib.FraudDetection.Criteria.CaseGroup
{
    using Fanex.Data.Repository;

    public class CaseGroupSelectCriteria : CriteriaBase
    {
        public int CaseId { get; set; }

        public override string GetSettingKey()
        {
            return "SPU_CaseGroupSel";
        }
        
        public override bool IsValid()
        {
            return CaseId > 0;
        }
    }
    
}