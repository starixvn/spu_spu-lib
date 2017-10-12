namespace FD.Lib.QueryGenerator
{
    using System.Linq;
    using Criteria.Task;

    public class RuleQueryGeneratorForSyncDataWithFPS : RuleQueryGenerator
    {
        public RuleQueryGeneratorForSyncDataWithFPS(int fraudCaseId, TaskInfoCriteria criteria)
            : base(fraudCaseId, criteria)
        {
            RelevantConfigIds = criteria.RuleConfigs;
        }

        public override string GenerateQuery()
        {
            if (IsNoRule)
            {
                return string.Empty;
            }

            if (RelevantConfigIds.Contains("46"))
            {
                return "GET_ASSOCIATION";
            }

            return RelevantConfigIds;
        }
    }
}
