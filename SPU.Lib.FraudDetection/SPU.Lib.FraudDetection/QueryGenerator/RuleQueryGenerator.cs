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
    using System;
    using System.Linq;
    using Criteria.Task;

    /// <summary>
    /// General Rule Query Generator.
    /// </summary>
    public class RuleQueryGenerator: QueryGenerator
    {
        private bool _isNearTheGoal;
        private bool _isCalculatedByPercentMaxBet;

        public RuleQueryGenerator(int fraudCaseId, TaskInfoCriteria criteria)
        {
            IsCountSuspiciousTime = criteria.ActivityId == CheckBettingHistory;
            OriginalFormula = criteria.TaskRules;
            RelevantConfigIds = criteria.RuleConfigs;
            GetConfigsInfo(fraudCaseId);
            _isNearTheGoal = OriginalFormula.Contains("NEARTHEGOAL");
            _isCalculatedByPercentMaxBet = OriginalFormula.Contains("% Max Bet");
        }

        /// <summary>
        /// Generate the WHOLE SQL statement.
        /// </summary>
        /// <returns>SQL string.</returns>
        public override string GenerateQuery()
        {
            var queryRuleString = "select distinct {0} from {1} where {2}";

            queryRuleString = string.Format(
                queryRuleString,
                GenerateSelectSql(),
                GenerateFromSql(),
                GenerateWhereSql(OriginalFormula));

            return queryRuleString.ToLower().Contains("sum(ans.stake*ans.actualrate)")
                ? ArrangeForSumStake(queryRuleString)
                : queryRuleString;
        }

        /// <summary>
        /// Generate the WHERE statement. This should be done by descendants.
        /// </summary>
        /// <param name="formula">Original Formula.</param>
        /// <returns>WHERE SQL string.</returns>
        protected override string GenerateWhereSql(string formula)
        {
            var requiredCondition =
                "ans.bettype IN (select distinct spb.BetType from bodb02.dbo.SportBettypeMatrix spb WITH(NOLOCK) where spb.ProductID = 1) and tch.matchid in ($param1$)";

            if (string.IsNullOrEmpty(RelevantConfigIds))
            {
                return string.Empty;
            }

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

            if (configIds.Any(configId => int.Parse(configId) == 30))
            {
                requiredCondition = requiredCondition + " and b.matchid in ($param1$)";
            }

            if (string.IsNullOrEmpty(formula))
            {
                return requiredCondition;
            }

            var dangerPeriodSql = Configs.Single(l => l.ConfigName.ToLower() == "in danger period").ConfigSQLField;
            OriginalFormula = OriginalFormula.Replace("NEARTHEGOAL", dangerPeriodSql);
            var sqlWhereString = requiredCondition + " and (" + OriginalFormula + ")";

            var afterRemoving = RemoveAllRedundantSpaces(sqlWhereString.Replace("%", "'").Replace("#", " ").Replace("@", " "));
            afterRemoving = afterRemoving.Replace("$LIKE$", "%");

            return afterRemoving;
        }

        private string ArrangeForSumStake(string originalStr)
        {
            var startIndex = originalStr.ToLower().IndexOf("sum(ans.stake*ans.actualrate)", StringComparison.Ordinal);
            var remainedString = originalStr.Substring(startIndex, originalStr.Length - startIndex).ToLower();
            var endIndex = remainedString.IndexOf("and", StringComparison.Ordinal) > 0
                ? remainedString.IndexOf("and", StringComparison.Ordinal)
                : (remainedString.IndexOf("or", StringComparison.Ordinal) > 0
                    ? remainedString.IndexOf("or", StringComparison.Ordinal)
                    : remainedString.Length - 1);
            var stakeConstraint = originalStr.Substring(startIndex, endIndex);

            if (!_isNearTheGoal)
            {
                var arrangedString = originalStr.Replace(stakeConstraint, "1=1 ") + " GROUP BY " + GenerateSelectSql();
                arrangedString += " HAVING " + stakeConstraint;

                return arrangedString;
            }

            var maxBet = stakeConstraint.Split(' ')[2];
            var operatorStake = stakeConstraint.Split(' ')[1];

            var extraSelect = ",sum(ans.stake*ans.actualrate) OVER (PARTITION BY ans.custid, ans.matchid, ans.bettype, ans.liveawayscore,ans.livehomescore) AS TotalStake,";
            extraSelect += maxBet + " AS MaxBet ";

            var groupBy = GenerateSelectSql() + (_isCalculatedByPercentMaxBet ? ",dds.maxbet,ans.bettype,ans.stake,ans.actualrate " : ",ans.bettype,ans.stake,ans.actualrate ");
            var fromQueryRuleString = "select distinct {0} from {1} where {2}";

            fromQueryRuleString = string.Format(
                fromQueryRuleString,
                GenerateSelectSql() + extraSelect,
                GenerateFromSql(),
                GenerateWhereSql(OriginalFormula).Replace(stakeConstraint, "1=1 ") + " GROUP BY " + groupBy);

            var newQueryRuleString = "select distinct {0} from ({1}) ans where {2}";
            var whereQueryRuleString = "ans.TotalStake " + operatorStake + " ans.Maxbet";

            newQueryRuleString = string.Format(
                newQueryRuleString,
                GenerateSelectSql(),
                fromQueryRuleString,
                whereQueryRuleString);

            return newQueryRuleString;
        }
    }
}