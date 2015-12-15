namespace FD.Lib.QueryGenerator
{
    using Criteria.Task;

    public class RuleQueryGeneratorForGroupingCustomer : RuleQueryGeneratorForGrouping
    {
        public RuleQueryGeneratorForGroupingCustomer(int fraudCaseId, TaskInfoCriteria criteria)
            : base(fraudCaseId, criteria)
        {
            groupingCondition = OriginalFormula;
            foreignKeyName = "temptable.betcount";
        }
    }
}