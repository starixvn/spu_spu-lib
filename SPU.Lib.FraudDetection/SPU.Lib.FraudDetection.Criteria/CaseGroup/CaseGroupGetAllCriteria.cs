namespace FD.Lib.Criteria.CaseGroup
{
    using Fanex.Data.Repository;

    public class CaseGroupGetAllCriteria : CriteriaBase
    {
        public int CaseId { get; set; }

        public override string GetSettingKey()
        {
            return "FD_CaseGroupGetAll";
        }
        
        public override bool IsValid()
        {
            return CaseId > 0;
        }
    }
}