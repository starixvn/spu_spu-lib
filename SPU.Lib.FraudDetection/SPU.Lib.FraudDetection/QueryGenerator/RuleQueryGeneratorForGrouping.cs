namespace FD.Lib.QueryGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.Task;
    using DTO;
    
    public abstract class RuleQueryGeneratorForGrouping : RuleQueryGenerator
    {
        protected Config GroupingConfig;

        protected Config SumWlByMatchConfig;

        protected string GroupingCondition;

        protected string SumWlByMatchCondition;

        protected string ForeignKeyName;

        public string GroupingConfigName { get; set; }

        protected IDictionary<string, string> additionalParams;

        private const string SumWlByMatchConfigName = "Sum WinLoss by Match";

        protected RuleQueryGeneratorForGrouping(int fraudCaseId, TaskInfoCriteria criteria)
            : base(fraudCaseId, criteria)
        {
            additionalParams = new Dictionary<string, string>();
        }

        public override string GenerateQuery()
        {
            PreGenerateQuery();

            GroupingConfig = Configs.Single(l => l.ConfigName == GroupingConfigName);
            RemoveSpecificConfigId(GroupingConfig.ConfigId.ToString());

            var rawSql = TablesForeignKey.Single(l => l.DBTable2 == ForeignKeyName).ForeignKey;
            var groupingCondition = string.Empty;

            OriginalFormula = RemoveGroupingConfig(OriginalFormula, GroupingConfigName, ref groupingCondition);
            GroupingCondition = groupingCondition;

            CreateAdditionalParams(OriginalFormula);

            var sql = ReplaceAdditionalParams(rawSql);

            sql = PostGenerateQuery(sql);

            sql = sql.Replace(Environment.NewLine, " ");

            return sql;
        }

        private void PreGenerateQuery()
        {
            var specificCondition = string.Empty;

            SumWlByMatchConfig = Configs.Single(l => l.ConfigName == SumWlByMatchConfigName);
            RemoveSpecificConfigId(SumWlByMatchConfig.ConfigId.ToString());
            OriginalFormula = RemoveGroupingConfig(OriginalFormula, SumWlByMatchConfigName,
                ref specificCondition);
            SumWlByMatchCondition = specificCondition;
        }

        private string PostGenerateQuery(string sql)
        {
            if (string.IsNullOrEmpty(SumWlByMatchCondition))
            {
                return sql.Replace("$additionalsumwl$", string.Empty);
            }

            SumWlByMatchCondition = SumWlByMatchCondition.Replace("%", string.Empty);
            var condition = SumWlByMatchCondition.Replace(SumWlByMatchConfigName, string.Empty);

            const string key = "temptable.sumwl";
            var foreignKey = TablesForeignKey.Single(t => t.DBTable2.Equals(key)).ForeignKey;

            foreignKey = foreignKey.Replace("$winlosscondition$", condition);

            return sql.Replace("$additionalsumwl$", foreignKey);
        }

        protected virtual void CreateAdditionalParams(string ruleConfigWithoutGroupingConfig)
        {
            var additionalFrom = GenerateFromSql();
            additionalParams.Add("additionalFrom", additionalFrom);

            var additionalWhere = GenerateWhereSql(ruleConfigWithoutGroupingConfig);
            additionalParams.Add("additionalWhere", additionalWhere);

            var additionalHaving = GroupingCondition.Replace(GroupingConfigName, GroupingConfig.ConfigSQLField);
            additionalParams.Add("additionalHaving", additionalHaving);
        }

        protected virtual string ReplaceAdditionalParams(string sql)
        {
            sql = sql.Replace("$additionalfrom$", additionalParams["additionalFrom"])
                .Replace("$additionalwhere$", additionalParams["additionalWhere"])
                .Replace("$additionalhaving$", additionalParams["additionalHaving"]);

            return sql;
        }

        protected void RemoveSpecificConfigId(string configId)
        {
            var startIndexOfConfigId = RelevantConfigIds.IndexOf(configId, StringComparison.Ordinal);

            if (startIndexOfConfigId < 0)
                return;

            if (startIndexOfConfigId == 0)
            {
                if (RelevantConfigIds.IndexOf("#", StringComparison.OrdinalIgnoreCase) < 0)
                {
                    RelevantConfigIds = string.Empty;
                }

                RelevantConfigIds = RelevantConfigIds.Replace(configId + "#", string.Empty);
            }

            RelevantConfigIds = RelevantConfigIds.Replace("#" + configId, string.Empty);
        }

        protected virtual string RemoveGroupingConfig(string formula, string configName, ref string specificCondition)
        {
            var startIndex = formula.IndexOf(configName, StringComparison.Ordinal);

            switch (startIndex)
            {
                case -1:
                    specificCondition = string.Empty;
                    return formula;

                case 0:
                    var startIndexOfAddress = formula.IndexOf('@');
                    var startIndexOfSharp = formula.IndexOf('#');
                    var finalRule = startIndexOfSharp >= 0
                        ? formula.Substring(startIndexOfSharp + 1, formula.Length - startIndexOfSharp - 1)
                        : string.Empty;

                    specificCondition = startIndexOfAddress >= 0 ? formula.Substring(0, startIndexOfAddress) : formula;
                    return finalRule;
            }

            var subString1 = formula.Substring(0, startIndex);
            var subString2 = formula.Substring(startIndex, formula.Length - startIndex);

            var startIndexSubStr1 = subString1.LastIndexOf('@');
            var startIndexSubStr2 = subString2.IndexOf('@');

            if (startIndexSubStr2 == -1)
            {
                specificCondition = subString2;

                return subString1.Substring(0, startIndexSubStr1);
            }

            var lastSubString1 = subString1.Substring(0, startIndexSubStr1);
            var lastSubString2 = subString2.Substring(startIndexSubStr2, subString2.Length - startIndexSubStr2);
            specificCondition = subString2.Substring(0, startIndexSubStr2);

            return lastSubString1 + lastSubString2;
        }
    }
}