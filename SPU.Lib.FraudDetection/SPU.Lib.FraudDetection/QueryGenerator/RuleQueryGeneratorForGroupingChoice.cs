namespace FD.Lib.QueryGenerator
{
    using System;
    using System.Linq;
    using Criteria.Task;

    public class RuleQueryGeneratorForGroupingChoice : RuleQueryGeneratorForGrouping
    {
        public RuleQueryGeneratorForGroupingChoice(int fraudCaseId, TaskInfoCriteria criteria)
            : base(fraudCaseId, criteria)
        {
            RuleConfig = OriginalFormula;
        }

        public override string GenerateQuery()
        {
            GroupingConfig = Configs.Single(l => l.ConfigName == GroupingConfigName);
            RemoveGroupingConfigId();

            var tableGroupBy = TablesForeignKey.Single(l => l.DBTable2 == "temptable.groupbychoice").ForeignKey;

            var ruleConfigAfterRemovedBetCount = RemoveGroupingConfig();

            var additionalFromForBetCount = GenerateFromSql();
            var additionalWhereForBetCount = GenerateWhereSql(ruleConfigAfterRemovedBetCount);
            var ruleWhere = RuleConfig.Replace(GroupingConfigName, GroupingConfig.ConfigSQLField);
            tableGroupBy = tableGroupBy.Replace("$groupbychoice_additionalfrom$", additionalFromForBetCount)
                .Replace("$groupbychoice_additionalwhere$", additionalWhereForBetCount)
                .Replace("$groupbychoice_additionalcount$", ruleWhere);

           var sql = tableGroupBy.Replace(System.Environment.NewLine, " ");

           return sql;
        }
    }
}