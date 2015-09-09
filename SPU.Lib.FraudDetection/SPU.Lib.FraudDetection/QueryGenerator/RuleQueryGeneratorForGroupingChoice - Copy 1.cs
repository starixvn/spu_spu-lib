namespace FD.Lib.QueryGenerator
{
    using Criteria.Task;

    public class RuleQueryGeneratorForGroupingIp : RuleQueryGeneratorForGrouping
    {
        public RuleQueryGeneratorForGroupingIp(int fraudCaseId, TaskInfoCriteria criteria)
            : base(fraudCaseId, criteria)
        {
            RuleConfig = OriginalFormula;
            ForeignKeyName = "temptable.groupbyip";
        }
    }
}