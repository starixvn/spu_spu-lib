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
    public class GroupBettingRuleQueryGenerator : QueryGenerator
    {
        public GroupBettingRuleQueryGenerator(int fraudCaseId, TaskInfoCriteria criteria)
        {
            IsCountSuspiciousTime = criteria.ActivityId == CheckBettingHistory;
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generate the WHERE statement. This should be done by descendants.
        /// </summary>
        /// <param name="formula">Original Formula.</param>
        /// <returns>WHERE SQL string.</returns>
        protected override string GenerateWhereSql(string formula)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Manage Bet Count Case.
        /// </summary>
        /// <param name="formula">Original formula.</param>
        /// <returns>Rule Configuration String.</returns>
        protected string ManageBetCountCase(string formula)
        {
            throw new NotImplementedException();
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
