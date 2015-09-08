namespace FD.Lib.BusinessManager.QueryGenerator
{
    using Criteria.Task;
    using Lib.QueryGenerator;

    public static class RuleQueryGeneratorFactory
    {
        private const string GroupByCustomer = "Bet Count On A Match";

        private const string Arbitrage = "Arbitrage";

        private const string GroupByChoice = "Group Betting Count By Choice";

        private const string GroupByIp = "Group Betting Count By IP";

        public static RuleQueryGenerator CreateRuleQueryGenerator(int fraudCaseId, TaskInfoCriteria criteria)
        {
            var originalFormula = criteria.TaskRules;

            if (originalFormula.IndexOf(GroupByCustomer, System.StringComparison.Ordinal) >= 0)
            {
                return new RuleQueryGeneratorForGroupingCustomer(fraudCaseId, criteria)
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

            if (originalFormula.IndexOf(GroupByIp, System.StringComparison.Ordinal) >= 0)
            {
                return new RuleQueryGeneratorForGroupingIp(fraudCaseId, criteria)
                {
                    GroupingConfigName = GroupByIp
                };
            }
            
            if (originalFormula.IndexOf(Arbitrage, System.StringComparison.Ordinal) >= 0)
            {
                return new RuleQueryGeneratorForGroupingArbitrage(fraudCaseId, criteria)
                {
                    GroupingConfigName = Arbitrage
                };
            }

            return new RuleQueryGenerator(fraudCaseId, criteria);
        }
    }
}