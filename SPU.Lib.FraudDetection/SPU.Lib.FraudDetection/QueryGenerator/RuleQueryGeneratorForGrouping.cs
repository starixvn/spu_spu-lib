namespace FD.Lib.QueryGenerator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.Task;
    using DTO;

    public abstract class RuleQueryGeneratorForGrouping : RuleQueryGenerator
    {
        protected Config GroupingConfig;

        protected string RuleConfig;

        protected string ForeignKeyName;

        public string GroupingConfigName { get; set; }

        protected IDictionary<string, string> additionalParams;

        protected RuleQueryGeneratorForGrouping(int fraudCaseId, TaskInfoCriteria criteria)
            : base(fraudCaseId, criteria)
        {
            additionalParams = new Dictionary<string, string>();
        }

        public override string GenerateQuery()
        {
            GroupingConfig = Configs.Single(l => l.ConfigName == GroupingConfigName);
            RemoveGroupingConfigId();

            var rawSql = TablesForeignKey.Single(l => l.DBTable2 == ForeignKeyName).ForeignKey;
            var ruleConfigWithoutGroupingConfig = RemoveGroupingConfig();

            CreateAdditionalParams(ruleConfigWithoutGroupingConfig);

            var sql = ReplaceAdditionalParams(rawSql);

            sql = sql.Replace(Environment.NewLine, " ");

            return sql;
        }

        protected virtual void CreateAdditionalParams(string ruleConfigWithoutGroupingConfig)
        {
            var additionalFrom = GenerateFromSql();
            additionalParams.Add("additionalFrom", additionalFrom);

            var additionalWhere = GenerateWhereSql(ruleConfigWithoutGroupingConfig);
            additionalParams.Add("additionalWhere", additionalWhere);

            var additionalHaving = RuleConfig.Replace(GroupingConfigName, GroupingConfig.ConfigSQLField);
            additionalParams.Add("additionalHaving", additionalHaving);
        }

        protected virtual string ReplaceAdditionalParams(string sql)
        {
            sql = sql.Replace("$additionalfrom$", additionalParams["additionalFrom"])
                .Replace("$additionalwhere$", additionalParams["additionalWhere"])
                .Replace("$additionalhaving$", additionalParams["additionalHaving"]);

            return sql;
        }

        protected void RemoveGroupingConfigId()
        {
            var configId = GroupingConfig.ConfigId.ToString();
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

        protected virtual string RemoveGroupingConfig()
        {
            var startIndex = RuleConfig.IndexOf(
                Configs.Single(l => l.ConfigName == GroupingConfigName).ConfigName,
                System.StringComparison.Ordinal);

            if (startIndex == 0)
            {
                var startIndexOfAddress = RuleConfig.IndexOf('@');
                var startIndexOfSharp = RuleConfig.IndexOf('#');
                var finalRule = RuleConfig.Substring(startIndexOfSharp + 1, RuleConfig.Length - startIndexOfSharp - 1);
                
                RuleConfig = RuleConfig.Substring(0, startIndexOfAddress);
                return finalRule;
            }

            var subString1 = RuleConfig.Substring(0, startIndex);
            var subString2 = RuleConfig.Substring(startIndex, RuleConfig.Length - startIndex);

            var startIndexSubStr1 = subString1.LastIndexOf('@');
            var startIndexSubStr2 = subString2.IndexOf('@');

            if (startIndexSubStr2 == -1)
            {
                RuleConfig = subString2;

                return subString1.Substring(0, startIndexSubStr1);
            }

            var lastSubString1 = subString1.Substring(0, startIndexSubStr1);
            var lastSubString2 = subString2.Substring(startIndexSubStr2, subString2.Length - startIndexSubStr2);
            RuleConfig = RuleConfig.Substring(0, startIndexSubStr2);

            return lastSubString1 + lastSubString2;
        }
    }
}