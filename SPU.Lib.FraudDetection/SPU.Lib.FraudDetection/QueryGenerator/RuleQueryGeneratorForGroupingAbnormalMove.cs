// --------------------------------------------------------------------------
// <copyright file="RuleQueryGeneratorForGroupingArbitrage.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.09.10">Created</change>
// </history>

namespace FD.Lib.QueryGenerator
{
    using Criteria.Task;

    public class RuleQueryGeneratorForGroupingAbnormalMove : RuleQueryGeneratorForGrouping
    {
        public RuleQueryGeneratorForGroupingAbnormalMove(int fraudCaseId, TaskInfoCriteria criteria)
            : base(fraudCaseId, criteria)
        {
            GroupingCondition = OriginalFormula;
            ForeignKeyName = "temptable.abnormalmove";
        }
        /*
        protected override void CreateAdditionalParams(string ruleConfigWithoutGroupingConfig)
        {
            var additionalFrom = string.IsNullOrEmpty(ruleConfigWithoutGroupingConfig) ? string.Empty : GenerateFromSql();
            additionalParams.Add("additionalFrom", string.IsNullOrEmpty(additionalFrom) ? "bodb02.dbo.bettrans ans with(nolock)" : additionalFrom);

            var additionalWhere = string.IsNullOrEmpty(ruleConfigWithoutGroupingConfig) ? string.Empty : GenerateWhereSql(ruleConfigWithoutGroupingConfig);
            additionalParams.Add("additionalWhere", string.IsNullOrEmpty(additionalWhere) ? string.Empty : " and " + additionalWhere);
        }

        protected override string ReplaceAdditionalParams(string sql)
        {
            sql = sql.Replace("$additionalfrom$", additionalParams["additionalFrom"])
                .Replace("$additionalwhere$", additionalParams["additionalWhere"]);

            return sql;
        }*/
    }
}