using System.Collections.Generic;
using System.Data;
using Fanex.NAP.Framework.Command;
using Fanex.NAP.Framework.Data;
using SPU.Lib.Core;
using SPU.Lib.FraudDetection.DTO;

namespace SPU.Lib.FraudDetection.Service
{
    public interface ITaskService
    {
        ICommandResult InsertTask(ICriteria criteria);

        ICommandResult DeleteTask(ICriteria criteria);

        DataCollection GetTasksByWorkflowId(ICriteria criteria);

        ICommandResult UpdateTask(ICriteria criteria);

        IEnumerable<TaskInfo> LoadAllTasks(ICriteria criteria);

        IEnumerable<Match> GetSuspiciousMatches(string query);

        IEnumerable<SuspiciousInfo> GetSuspiciousTickets(string query);

        IEnumerable<TablesForeignKey> GetTablesForeignKey(ICriteria criteria);

        /// <summary>
        /// Collect Suspicious Info.
        /// </summary>
        /// <param name="sqlQueryString">Query string.</param>
        /// <returns>List of suspicious information.</returns>
        IEnumerable<SuspiciousInfo> CollectSuspiciousInfo(string sqlQueryString);

        /// <summary>
        /// Return a list of ids.
        /// </summary>
        /// <param name="sqlQueryString">The query string.</param>
        /// <returns>List of ids.</returns>
        IEnumerable<string> ExecutePrecondition(string sqlQueryString);

        List<SuspiciousInfo> ExecuteRule(string sqlQueryString, int workflowId);

        IEnumerable<T> GetData<T>(ICriteria criteria);

        IEnumerable<T> GetData<T>(dynamic paramaters);

        IEnumerable<T> GetData<T>(ICriteria criteria, ref int totalPages);

        /// <summary>
        /// Execute Non Query Inline.
        /// </summary>
        /// <param name="sqlQueryString">Query string.</param>
        /// <returns>Command result.</returns>
        ICommandResult ExecuteNonQueryInline(string sqlQueryString);

        /// <summary>
        /// Execute Reader Query Inline.
        /// </summary>
        /// <param name="sqlQueryString">Query string.</param>
        /// <returns>Data table.</returns>
        DataTable ExecuteReaderQueryInline(string sqlQueryString);
    }
}