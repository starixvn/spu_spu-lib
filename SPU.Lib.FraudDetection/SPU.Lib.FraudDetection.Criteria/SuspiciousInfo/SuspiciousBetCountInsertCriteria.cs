namespace FD.Lib.Criteria.SuspiciousInfo
{
    using Fanex.Data.Repository;

    public class SuspiciousBetCountInsertCriteria : CriteriaBase
    {
        public string SuspiciousDoc { get; set; }

        public override string GetSettingKey()
        {
            return "FD_SuspiciousBetCountInsert";
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(SuspiciousDoc);
        }
    }
}