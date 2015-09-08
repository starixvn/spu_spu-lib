// --------------------------------------------------------------------------
// <copyright file="RuleQueryGeneratorForGroupingArbitrage.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.09.07">Created</change>
// </history>

namespace FD.Lib.QueryGenerator
{
    using Criteria.Task;

    public class RuleQueryGeneratorForGroupingArbitrage : RuleQueryGeneratorForGrouping
    {
        public RuleQueryGeneratorForGroupingArbitrage(int fraudCaseId, TaskInfoCriteria criteria)
            : base(fraudCaseId, criteria)
        {
            RuleConfig = OriginalFormula;
            ForeignKeyName = "temptable.arbitrage";
        }

        protected override void CreateAdditionalParams(string ruleConfigWithoutGroupingConfig)
        {
            var additionalFrom = GenerateFromSql();
            additionalParams.Add("additionalFrom", string.IsNullOrEmpty(additionalFrom) ? string.Empty : " and " + additionalFrom);

            var additionalWhere = GenerateWhereSql(ruleConfigWithoutGroupingConfig);
            additionalParams.Add("additionalWhere", string.IsNullOrEmpty(additionalWhere) ? string.Empty : " and " + additionalWhere);
        }

        protected override string ReplaceAdditionalParams(string sql)
        {
            sql = sql.Replace("$additionalfrom$", additionalParams["additionalFrom"])
                .Replace("$additionalwhere$", additionalParams["additionalWhere"]);

            return sql;
        }
    }
}