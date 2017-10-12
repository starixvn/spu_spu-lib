namespace FD.Lib.QueryGenerator
{
    using System.Linq;
    using Criteria.Task;

    public class PreConditionQueryGeneratorForSyncDataWithFPS : PreConditionQueryGenerator
    {
        public PreConditionQueryGeneratorForSyncDataWithFPS(
            int fraudCaseId,
            TaskInfoCriteria criteria,
            int chunkOfSelection)
            : base(fraudCaseId, criteria, chunkOfSelection)
        {
            IsNoRule = string.IsNullOrEmpty(criteria.TaskPreconditionsOriginal);

            if (!IsNoRule)
            {
                OriginalFormula = criteria.TaskPreconditions;
                PreConditionRawFormula = criteria.TaskPreconditionsOriginal;
                RelevantConfigIds = criteria.PreconConfigs;
                GetConfigsInfo(fraudCaseId, criteria.ActivityId);
            }
        }

        private string PreConditionRawFormula { get; set; }

        public override string GenerateQuery()
        {
            if (IsNoRule)
            {
                return string.Empty;
            }

            var queryPreconString = "select distinct {0} from {1} where {2}";

            return string.Format(
                queryPreconString,
                GenerateSelectSql(),
                GenerateFromSql(),
                GenerateWhereSql(OriginalFormula));
        }

        private new string GenerateFromSql()
        {
            var sqlFromString = "dbo.CustomerGroups ups WITH (nolock)";

            var relevantTables = GenerateRelevantTables();
            if (string.IsNullOrEmpty(relevantTables))
            {
                return string.Empty;
            }

            var tables = relevantTables.Split(',');
            foreach (var table in tables)
            {
                sqlFromString += TablesForeignKey.Single(l => l.DBTable2.Trim().ToLower() == table.Trim().ToLower()).ForeignKey;
            }

            return RemoveAllRedundantSpaces(sqlFromString);
        }

        private new string GenerateWhereSql(string formula)
        {
            OriginalFormula = formula;

            var configIds = RelevantConfigIds.Split('#');
            foreach (var config in configIds.Select(configId => Configs.Single(l => l.ConfigId == int.Parse(configId))))
            {
                OriginalFormula = OriginalFormula.Replace(config.ConfigName, config.ConfigSQLField);
            }

            return RemoveAllRedundantSpaces(OriginalFormula.Replace("%", "'").Replace("#", " ").Replace("@", " "));
        }
    }
}
