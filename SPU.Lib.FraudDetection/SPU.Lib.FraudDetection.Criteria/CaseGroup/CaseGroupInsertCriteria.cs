namespace SPU.Lib.FraudDetection.Service.UnitTest
{
    using Fanex.Data.Repository;

    public class CaseGroupInsertCriteria : CriteriaBase
    {
        public int CaseId { get; set; }

        public int GroupId { get; set; }
        
        public override string GetSettingKey()
        {
            return "SPU_CaseGroupIns";
        }
        
        public override bool IsValid()
        {
            return CaseId > 0 && GroupId > 0;
        }
    }
}