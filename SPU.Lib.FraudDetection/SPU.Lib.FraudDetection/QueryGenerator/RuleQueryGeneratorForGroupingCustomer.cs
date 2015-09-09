namespace FD.Lib.QueryGenerator
{
    using System.Linq;
    using Criteria.Task;

    public class RuleQueryGeneratorForGroupingCustomer : RuleQueryGeneratorForGrouping
    {
        public RuleQueryGeneratorForGroupingCustomer(int fraudCaseId, TaskInfoCriteria criteria)
            : base(fraudCaseId, criteria)
        {
            RuleConfig = OriginalFormula;
            ForeignKeyName = "temptable.betcount";
        }
    }
}