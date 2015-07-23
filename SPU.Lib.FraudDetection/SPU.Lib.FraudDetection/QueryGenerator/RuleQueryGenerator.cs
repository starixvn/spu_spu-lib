// --------------------------------------------------------------------------
// <copyright file="RuleQueryGenerator.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.QueryGenerator
{
    using System.Linq;

    /// <summary>
    /// General Rule Query Generator.
    /// </summary>
    public class RuleQueryGenerator : QueryGenerator
    {
        public RuleQueryGenerator(int fraudCaseId)
        {
            GetConfigsInfo(fraudCaseId);
        }

        /// <summary>
        /// Generate the WHOLE SQL statement.
        /// </summary>
        /// <returns>SQL string.</returns>
        public override string GenerateQuery()
        {
            const string queryRuleString = "select distinct {0} from {1} where {2}";

            return string.Format(
                queryRuleString,
                GenerateSelectSql(),
                GenerateFromSql(),
                GenerateWhereSql()
                );
        }

        /// <summary>
        /// Generate the WHERE statement. This should be done by descendants.
        /// </summary>
        /// <returns>WHERE SQL string.</returns>
        protected override string GenerateWhereSql()
        {
            var configIds = RelevantConfigIds.Split('#');
            foreach (var config in configIds.Select(configId => Configs.Single(l => l.ConfigId == int.Parse(configId))))
            {
                OriginalFormula = OriginalFormula.Replace(config.ConfigName, config.ConfigSQLField);
            }

            var dangerPeriodSql = Configs.Single(l => l.ConfigName.ToLower() == "in danger period").ConfigSQLField;
            OriginalFormula = OriginalFormula.Replace("NEARTHEGOAL", dangerPeriodSql);
            var sqlWhereString = "ans.liveindicator = 1 and tch.matchid in ($param1$) and (" + OriginalFormula + ")";

            return RemoveAllRedundantSpaces(sqlWhereString.Replace("%", "'").Replace("#", " ").Replace("@", " "));
        }
    }
}
