// --------------------------------------------------------------------------
// <copyright file="RuleQueryGenerator.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.QueryGenerator
{
    using System.Linq;
    using Criteria.Task;

    /// <summary>
    /// General Rule Query Generator.
    /// </summary>
    public class RuleQueryGenerator : QueryGenerator
    {
        public RuleQueryGenerator(int fraudCaseId, TaskInfoCriteria criteria)
        {
            IsCountSuspiciousTime = criteria.EventId == CheckBettingHistory;
            OriginalFormula = criteria.TaskRules;
            RelevantConfigIds = criteria.RuleConfigs;
            GetConfigsInfo(fraudCaseId);
        }

        /// <summary>
        /// Generate the WHOLE SQL statement.
        /// </summary>
        /// <returns>SQL string.</returns>
        public override string GenerateQuery()
        {
            const string queryRuleString = "select distinct {0} from {1} where {2}";

            return string.Format(queryRuleString,
                           GenerateSelectSql(),
                           GenerateFromSql(),
                           GenerateWhereSql(OriginalFormula));
        }

        /// <summary>
        /// Generate the WHERE statement. This should be done by descendants.
        /// </summary>
        /// <param name="formula">Original Formula.</param>
        /// <returns>WHERE SQL string.</returns>
        protected override string GenerateWhereSql(string formula)
        {
            const string requiredCondition =
                "ans.bettype IN (select distinct spb.BetType from bodb02.dbo.SportBettypeMatrix spb WITH(NOLOCK) where spb.ProductID = 1) and tch.matchid in ($param1$)";

            if (string.IsNullOrEmpty(RelevantConfigIds))
                return string.Empty;

           
            OriginalFormula = formula;
            var configIds = RelevantConfigIds.Split('#');
            foreach (var config in configIds.Select(configId => Configs.Single(l => l.ConfigId == int.Parse(configId))))
            {
                OriginalFormula = OriginalFormula.Replace(config.ConfigName, config.ConfigSQLField);
            }
            
            if (IsCountSuspiciousTime)
            {
                return OriginalFormula;
            }

            if (string.IsNullOrEmpty(formula))
            {
                return requiredCondition;
            }

            var dangerPeriodSql = Configs.Single(l => l.ConfigName.ToLower() == "in danger period").ConfigSQLField;
            OriginalFormula = OriginalFormula.Replace("NEARTHEGOAL", dangerPeriodSql);
            var sqlWhereString = requiredCondition + " and (" + OriginalFormula + ")";

            var afterRemoving = RemoveAllRedundantSpaces(sqlWhereString.Replace("%", "'").Replace("#", " ").Replace("@", " "));

            return afterRemoving;
        }
    }
}
