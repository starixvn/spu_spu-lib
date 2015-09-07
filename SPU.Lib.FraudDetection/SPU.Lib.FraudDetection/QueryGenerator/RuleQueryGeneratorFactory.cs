namespace FD.Lib.BusinessManager.QueryGenerator
{
    using Criteria.Task;
    using Lib.QueryGenerator;

    public static class RuleQueryGeneratorFactory
    {
        private const string GroupByCustomer = "Bet Count On A Match";

        private const string GroupByChoice = "Group Betting Count By Choice";

        public static RuleQueryGenerator CreateRuleQueryGenerator(int fraudCaseId, TaskInfoCriteria criteria)
        {
            var originalFormula = criteria.TaskRules;

            if (originalFormula.IndexOf(GroupByCustomer, System.StringComparison.Ordinal) >= 0)
            {
                return new RuleQueryGeneratorForGroupingCusomter(fraudCaseId, criteria)
                {
                    GroupingConfigName = GroupByCustomer
                };
            }

            if (originalFormula.IndexOf(GroupByChoice, System.StringComparison.Ordinal) >= 0)
            {
                return new RuleQueryGeneratorForGroupingChoice(fraudCaseId, criteria)
                {
                    GroupingConfigName = GroupByChoice
                };
            }

            return new RuleQueryGenerator(fraudCaseId, criteria);
        }
    }
}