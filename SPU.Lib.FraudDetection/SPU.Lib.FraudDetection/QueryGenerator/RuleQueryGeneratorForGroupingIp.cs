namespace FD.Lib.BusinessManager.QueryGenerator
{
    using Criteria.Task;
    using Lib.QueryGenerator;

    public class RuleQueryGeneratorForGroupingIp : RuleQueryGeneratorForGrouping
    {
        public RuleQueryGeneratorForGroupingIp(int fraudCaseId, TaskInfoCriteria criteria)
            : base(fraudCaseId, criteria)
        {
            groupingCondition = OriginalFormula;
            foreignKeyName = "temptable.groupbyip";
        }
    }
}