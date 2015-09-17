// --------------------------------------------------------------------------
// <copyright file="PreConditionQueryGenerator.cs" company="Nexcel Solutions Vietnam">
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
    /// General Pre-Condition Query Generator.
    /// </summary>
    public class PreConditionQueryGenerator : QueryGenerator
    {
        public PreConditionQueryGenerator(
            int fraudCaseId,
            TaskInfoCriteria criteria,
            int chunkOfSelection)
        {
            IsCountSuspiciousTime = criteria.EventId == CheckBettingHistory;
            IsCheckNotScanned = criteria.IsCheckNotScanned;
            ChunkOfSelection = chunkOfSelection;
            OriginalFormula = criteria.TaskPreconditions;
            PreConditionRawFormula = criteria.TaskPreconditionsOriginal;
            RelevantConfigIds = criteria.PreconConfigs;
            GetConfigsInfo(fraudCaseId);
        }

        private bool IsCheckNotScanned { get; set; }

        private int ChunkOfSelection { get; set; }

        private string PreConditionRawFormula { get; set; }

        /// <summary>
        /// Generate the WHOLE SQL statement.
        /// </summary>
        /// <returns>SQL string.</returns>
        public override string GenerateQuery()
        {
            var queryPreconString = !IsCountSuspiciousTime
                ? "select distinct top " + ChunkOfSelection + " {0} from {1} where {2}"
                : "select distinct {0} from {1} where {2}";

            return string.Format(
                queryPreconString,
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
            var isSelectScanningState = PreConditionRawFormula.Contains("Match State");
            var sqlForNotScanned = Configs.Single(l => l.ConfigName.ToLower() == "match state").ConfigSQLField;
            var configIds = RelevantConfigIds.Split('#');
            foreach (var config in configIds.Select(configId => Configs.Single(l => l.ConfigId == int.Parse(configId))))
            {
                OriginalFormula = OriginalFormula.Replace(config.ConfigName, config.ConfigSQLField);
            }

            if (IsCountSuspiciousTime)
            {
                return OriginalFormula;
            }

            var sqlWhereString = "tch.sporttype between 1 and 99 and " + OriginalFormula;
            if (isSelectScanningState && IsCheckNotScanned)
            {
                sqlWhereString = sqlWhereString.Replace("$MatchState$", "tch.matchid not in (" + sqlForNotScanned + ")");
            }
            else
            {
                sqlWhereString = sqlWhereString.Replace("$MatchState$", "1=1");
            }


            return RemoveAllRedundantSpaces(sqlWhereString.Replace("%", "'").Replace("#", " ").Replace("@", " "));
        }
    }
}
