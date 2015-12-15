namespace FD.Lib.QueryGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.Task;
    using DTO;
    
    public abstract class RuleQueryGeneratorForGrouping : RuleQueryGenerator
    {
        protected Config groupingConfig;

        protected Config sumWlByMatchConfig;

        protected string groupingCondition;

        protected string sumWlByMatchCondition;

        protected string foreignKeyName;

        public string groupingConfigName { get; set; }

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

            groupingConfig = Configs.Single(l => l.ConfigName == groupingConfigName);
            RemoveSpecificConfigId(groupingConfig.ConfigId.ToString());

            var rawSql = TablesForeignKey.Single(l => l.DBTable2 == foreignKeyName).ForeignKey;
            var groupingCondition = string.Empty;

            OriginalFormula = RemoveGroupingConfig(OriginalFormula, groupingConfigName, ref groupingCondition);
            this.groupingCondition = groupingCondition;

            CreateAdditionalParams(OriginalFormula);

            var sql = ReplaceAdditionalParams(rawSql);

            sql = PostGenerateQuery(sql);

            sql = sql.Replace(Environment.NewLine, " ");

            return sql;
        }

        private void PreGenerateQuery()
        {
            var specificCondition = string.Empty;

            sumWlByMatchConfig = Configs.Single(l => l.ConfigName == SumWlByMatchConfigName);
            RemoveSpecificConfigId(sumWlByMatchConfig.ConfigId.ToString());
            OriginalFormula = RemoveGroupingConfig(OriginalFormula, SumWlByMatchConfigName, ref specificCondition);
            sumWlByMatchCondition = specificCondition;
        }

        private string PostGenerateQuery(string sql)
        {
            if (string.IsNullOrEmpty(sumWlByMatchCondition))
            {
                return sql.Replace("$additionalsumwl$", string.Empty);
            }

            sumWlByMatchCondition = sumWlByMatchCondition.Replace("%", string.Empty);
            var condition = sumWlByMatchCondition.Replace(SumWlByMatchConfigName, string.Empty);

            const string Key = "temptable.sumwl";
            var foreignKey = TablesForeignKey.Single(t => t.DBTable2.Equals(Key)).ForeignKey;

            foreignKey = foreignKey.Replace("$winlosscondition$", condition);

            return sql.Replace("$additionalsumwl$", foreignKey);
        }

        protected virtual void CreateAdditionalParams(string ruleConfigWithoutGroupingConfig)
        {
            var additionalFrom = GenerateFromSql();
            additionalParams.Add("additionalFrom", additionalFrom);

            var additionalWhere = GenerateWhereSql(ruleConfigWithoutGroupingConfig);
            additionalParams.Add("additionalWhere", additionalWhere);

            var additionalHaving = groupingCondition.Replace(groupingConfigName, groupingConfig.ConfigSQLField);
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
            {
                return;
            }

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