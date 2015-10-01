// --------------------------------------------------------------------------
// <copyright file="RuleQueryGeneratorForComparingData.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.10.01">Created</change>
// </history>

namespace FD.Lib.QueryGenerator
{
    using System.Linq;
    using Criteria.Task;

    /// <summary>
    /// General Rule Query Generator.
    /// </summary>
    public class RuleQueryGeneratorForComparingData : RuleQueryGenerator
    {
        public RuleQueryGeneratorForComparingData(int fraudCaseId, TaskInfoCriteria criteria)
            : base(fraudCaseId, criteria)
        {
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
            return string.Format(
                "select distinct {0} from {1} where {2}",
                GenerateSelectSql(),
                GenerateFromSql(),
                GenerateWhereSql(OriginalFormula));
        }

        private new string GenerateFromSql()
        {
            const string sqlFromString = "dbo.CapturedData cd WITH (nolock)";

            return sqlFromString;
        }

        /// <summary>
        /// Generate the WHERE statement. This should be done by descendants.
        /// </summary>
        /// <param name="formula">Original Formula.</param>
        /// <returns>WHERE SQL string.</returns>
        protected override string GenerateWhereSql(string formula)
        {
            const string requiredCondition = "cd.matchid IN ($param1$)";

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

            if (string.IsNullOrEmpty(formula))
            {
                return requiredCondition;
            }

            var sqlWhereString = requiredCondition + " and (" + OriginalFormula + ")";

            var afterRemoving = RemoveAllRedundantSpaces(sqlWhereString.Replace("%", "'").Replace("#", " ").Replace("@", " "));

            return afterRemoving;
        }
    }
}
