namespace FD.Lib.BusinessManager.QueryGenerator
{
    using Criteria.Task;
    using Lib.QueryGenerator;

    public static class RuleQueryGeneratorFactory
    {
        private const string GroupByCustomer = "Bet Count On A Match";

        private const string Arbitrage = "Arbitrage";

        private const string AbnormalMove = "Abnormal Move";

        private const string GroupByChoice = "Group Betting Count By Choice";

        private const string GroupByIp = "Group Betting Count By IP";

        public static RuleQueryGenerator CreateRuleQueryGenerator(int fraudCaseId, TaskInfoCriteria criteria)
        {
            var originalFormula = criteria.TaskRules;

            if (criteria.ActivityId == (int)ActivityType.ScanMatchCompareData)
            {
                return new RuleQueryGeneratorForComparingData(fraudCaseId, criteria);
            }

            if (criteria.ActivityId == (int)ActivityType.ScanCustomerSyncData)
            {
                return new RuleQueryGeneratorForSyncDataWithFPS(fraudCaseId, criteria);
            }

            ////if (originalFormula.IndexOf(GroupByCustomer, System.StringComparison.Ordinal) >= 0)
            ////{
            ////    return new RuleQueryGeneratorForGroupingCustomer(fraudCaseId, criteria)
            ////    {
            ////        groupingConfigName = GroupByCustomer
            ////    };
            ////}

            ////if (originalFormula.IndexOf(GroupByChoice, System.StringComparison.Ordinal) >= 0)
            ////{
            ////    return new RuleQueryGeneratorForGroupingChoice(fraudCaseId, criteria)
            ////    {
            ////        groupingConfigName = GroupByChoice
            ////    };
            ////}

            ////if (originalFormula.IndexOf(GroupByIp, System.StringComparison.Ordinal) >= 0)
            ////{
            ////    return new RuleQueryGeneratorForGroupingIp(fraudCaseId, criteria)
            ////    {
            ////        groupingConfigName = GroupByIp
            ////    };
            ////}
            
            ////if (originalFormula.IndexOf(Arbitrage, System.StringComparison.Ordinal) >= 0)
            ////{
            ////    return new RuleQueryGeneratorForGroupingArbitrage(fraudCaseId, criteria)
            ////    {
            ////        groupingConfigName = Arbitrage
            ////    };
            ////}

            ////if (originalFormula.IndexOf(AbnormalMove, System.StringComparison.Ordinal) >= 0)
            ////{
            ////    return new RuleQueryGeneratorForGroupingAbnormalMove(fraudCaseId, criteria)
            ////    {
            ////        groupingConfigName = AbnormalMove
            ////    };
            ////}

            return new RuleQueryGenerator(fraudCaseId, criteria);
        }
    }
}