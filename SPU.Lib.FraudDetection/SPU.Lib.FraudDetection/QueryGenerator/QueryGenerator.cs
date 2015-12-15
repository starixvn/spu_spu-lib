// --------------------------------------------------------------------------
// <copyright file="QueryGenerator.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.QueryGenerator
{
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.Config;
    using Criteria.Task;
    using DTO;
    using Service.Implement;

    /// <summary>
    /// General Query Generator.
    /// </summary>
    public abstract class QueryGenerator
    {
        protected const int CheckBettingHistory = 2;

        protected string OriginalFormula { get; set; }

        protected string RelevantConfigIds { get; set; }

        protected List<Config> Configs { get; set; }

        protected List<TablesForeignKey> TablesForeignKey { get; set; }

        protected bool IsCountSuspiciousTime { get; set; }

        /// <summary>
        /// Generate the WHOLE SQL statement.
        /// </summary>
        /// <returns>SQL string.</returns>
        public abstract string GenerateQuery();

        /// <summary>
        /// Get Configurations Information.
        /// </summary>
        /// <param name="caseId">Fraud case ID.</param>
        protected void GetConfigsInfo(int caseId)
        {
            var taskService = new TaskService();
            TablesForeignKey = taskService.GetTablesForeignKey(new TablesForeignKeyGetAllCriteria()).ToList();

            var configurationService = new ConfigurationsService();
            Configs = configurationService.GetFormattedConfigs(new ConfigGetAllCriteria(), caseId);
        }

        /// <summary>
        /// Generate the SELECT statement.
        /// </summary>
        /// <returns>SELECT SQL string.</returns>
        protected string GenerateSelectSql()
        {
            var sqlSelectString = string.Empty;
            var configsList = RelevantConfigIds.Split('#');
            foreach (var config in configsList)
            {
                var currentRelevantReturns = Configs.Single(l => l.ConfigId == int.Parse(config)).ConfigSQLReturn.Split(',');
                foreach (var currentReturn in currentRelevantReturns)
                {
                    if (!sqlSelectString.Contains(currentReturn))
                    {
                        sqlSelectString += currentReturn + ",";
                    }
                }
            }

            return sqlSelectString.Remove(sqlSelectString.Length - 1);
        }

        /// <summary>
        /// Generate the FROM statement.
        /// </summary>
        /// <returns>FROM SQL string.</returns>
        protected string GenerateFromSql()
        {
            var sqlFromString = "bodb02.dbo.match tch with(nolock) ";
            var relevantTables = GenerateRelevantTables();
            if (string.IsNullOrEmpty(relevantTables))
            {
                return string.Empty;
            }

            if (relevantTables.ToLower().Contains("count("))
            {
                return relevantTables;
            }

            var tables = relevantTables.Split(',');
            foreach (var table in tables)
            {
                sqlFromString += TablesForeignKey.Single(l => l.DBTable2.Trim().ToLower() == table.Trim().ToLower()).ForeignKey;
            }

            return RemoveAllRedundantSpaces(sqlFromString);
        }

        /// <summary>
        /// Generate the WHERE statement. This should be done by descendants.
        /// </summary>
        /// <param name="formula">Original Formula.</param>
        /// <returns>WHERE SQL string.</returns>
        protected abstract string GenerateWhereSql(string formula);

        #region Ultilites

        /// <summary>
        /// Generate Relevant Tables.
        /// </summary>
        /// <returns>List of selected tables.</returns>
        protected string GenerateRelevantTables()
        {
            if (string.IsNullOrEmpty(RelevantConfigIds))
            {
                return string.Empty;
            }

            var relevantTables = string.Empty;
            var configsList = RelevantConfigIds.Split('#');

            foreach (var config in configsList)
            {
                var currentRelevantTables = Configs.Single(l => l.ConfigId == int.Parse(config)).ConfigSQLTable.Split(',');

                foreach (var currentTable in currentRelevantTables)
                {
                    if (!relevantTables.Contains(currentTable))
                    {
                        relevantTables += currentTable + ",";
                    }
                }
            }

            return relevantTables.Remove(relevantTables.Length - 1);
        }

        /// <summary>
        /// Remove All Redundant Spaces in a string.
        /// </summary>
        /// <param name="originalString">Original String.</param>
        /// <returns>Trimmed string.</returns>
        protected string RemoveAllRedundantSpaces(string originalString)
        {
            const System.Text.RegularExpressions.RegexOptions Options = System.Text.RegularExpressions.RegexOptions.None;
            var regex = new System.Text.RegularExpressions.Regex(@"[ ]{2,}", Options);
            originalString = regex.Replace(originalString, @" ");

            return originalString;
        }

        #endregion
    }
}
