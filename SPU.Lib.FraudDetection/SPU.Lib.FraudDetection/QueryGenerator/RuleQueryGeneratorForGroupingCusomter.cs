namespace FD.Lib.QueryGenerator
{
    using System.Linq;
    using Criteria.Task;

    public class RuleQueryGeneratorForGroupingCusomter : RuleQueryGeneratorForGrouping
    {
        public RuleQueryGeneratorForGroupingCusomter(int fraudCaseId, TaskInfoCriteria criteria)
            : base(fraudCaseId, criteria)
        {
            RuleConfig = OriginalFormula;
        }

        public override string GenerateQuery()
        {
            GroupingConfig = Configs.Single(l => l.ConfigName == GroupingConfigName);
            RemoveGroupingConfigId();

            var tableBetCount = TablesForeignKey.Single(l => l.DBTable2 == "temptable.betcount").ForeignKey;
            var ruleConfigAfterRemovedBetCount = RemoveGroupingConfig();

            var additionalFromForBetCount = GenerateFromSql();
            var additionalWhereForBetCount = GenerateWhereSql(ruleConfigAfterRemovedBetCount);
            var ruleWhere = RuleConfig.Replace(GroupingConfigName, GroupingConfig.ConfigSQLField);
            tableBetCount = tableBetCount.Replace("$betcount_additionalfrom$", additionalFromForBetCount)
                .Replace("$betcount_additionalwhere$", additionalWhereForBetCount)
                .Replace("$betcount_additionalcount$", ruleWhere);

            var sql = tableBetCount.Replace(System.Environment.NewLine, " ");

            return sql;
        }
    }
}