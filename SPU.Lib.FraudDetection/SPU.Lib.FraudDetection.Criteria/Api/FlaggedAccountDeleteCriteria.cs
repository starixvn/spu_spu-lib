namespace FD.Lib.Criteria.Case
{
    using Fanex.Data.Repository;

    public class FlaggedAccountDeleteCriteria : CriteriaBase
    {
        public string EviCode { get; set; }

        public string DirectAccounts { get; set; }

        public string IndirectAccounts { get; set; }

        public override string GetSettingKey()
        {
            return "FD_FlaggedAccountDelete";
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(EviCode);
        }
    }
}