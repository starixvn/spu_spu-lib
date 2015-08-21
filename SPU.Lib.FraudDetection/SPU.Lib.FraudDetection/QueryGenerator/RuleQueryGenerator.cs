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

            return OriginalFormula.IndexOf("Bet Count On A Match", System.StringComparison.Ordinal) > 0
                       ? ManageBetCountCase(OriginalFormula, queryRuleString)
                       : string.Format(
                           queryRuleString,
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

            var dangerPeriodSql = Configs.Single(l => l.ConfigName.ToLower() == "in danger period").ConfigSQLField;
            OriginalFormula = OriginalFormula.Replace("NEARTHEGOAL", dangerPeriodSql);
            var sqlWhereString = "ans.liveindicator = 1 AND ans.bettype IN (select distinct spb.BetType from bodb02.dbo.SportBettypeMatrix spb WITH(NOLOCK) where spb.ProductID = 1) and tch.matchid in ($param1$) and (" + OriginalFormula + ")";

            return RemoveAllRedundantSpaces(sqlWhereString.Replace("%", "'").Replace("#", " ").Replace("@", " "));
        }

        protected string ManageBetCountCase(string formula, string queryRuleString)
        {
            RelevantConfigIds = RelevantConfigIds.Replace("#17",string.Empty);
            var tableBetCount = TablesForeignKey.Single(l => l.DBTable2 == "temptable.betcount").ForeignKey;
            var ruleConfig = formula;
            var ruleConfigAfterRemovedBetCount = RemoveBetCountConfig(ref ruleConfig);

            var additionalFromForBetCount = GenerateFromSql();
            var additionalWhereForBetCount = GenerateWhereSql(ruleConfigAfterRemovedBetCount);
            var ruleWhere = ruleConfig.Replace("Bet Count On A Match", "unt.ticketscounter");
            tableBetCount = tableBetCount.Replace("$betcount_additionalfrom$", additionalFromForBetCount)
                         .Replace("$betcount_additionalwhere$", " AND " + additionalWhereForBetCount);

            return string.Format(
                queryRuleString,
                GenerateSelectSql(),
                tableBetCount,
                ruleWhere);
        }

        #region Utilities

        private string RemoveBetCountConfig(ref string ruleString)
        {
            var startIndex = ruleString.IndexOf(
                Configs.Single(l => l.ConfigName == "Bet Count On A Match").ConfigName, 
                System.StringComparison.Ordinal);
            var subString1 = ruleString.Substring(0, startIndex);
            var subString2 = ruleString.Substring(startIndex, ruleString.Length - startIndex);

            var startIndexSubStr1 = subString1.LastIndexOf('@');
            var startIndexSubStr2 = subString2.IndexOf('@');
            ruleString = startIndexSubStr2 > -1 ? subString2.Substring(0, startIndexSubStr2) : subString2;

            return subString1.Substring(0, startIndexSubStr1) + (startIndexSubStr2 > -1 ? subString2.Substring(startIndexSubStr2, subString2.Length - startIndexSubStr2) : string.Empty);
        }


        #endregion
    }
}
