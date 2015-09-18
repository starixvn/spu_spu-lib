namespace FD.Lib.QueryGenerator
{
    using Criteria.Task;

    public class RuleQueryGeneratorForGroupingChoice : RuleQueryGeneratorForGrouping
    {
        public RuleQueryGeneratorForGroupingChoice(int fraudCaseId, TaskInfoCriteria criteria)
            : base(fraudCaseId, criteria)
        {
            GroupingCondition = OriginalFormula;
            ForeignKeyName = "temptable.groupbychoice";
        }
    }
}