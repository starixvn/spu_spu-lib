// --------------------------------------------------------------------------
// <copyright file="ITaskService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Interface
{
    using System.Collections.Generic;
    using System.Data;
    using Core;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Implement;

    /// <summary>
    ///     Task Service interface.
    /// </summary>
    public interface ITaskService
    {
        ICommandResult InsertTask(ICriteria criteria);
        ICommandResult DeleteTask(ICriteria criteria);
        DataCollection GetTasksByWorkflowId(ICriteria criteria);
        ICommandResult UpdateTask(ICriteria criteria);
        IEnumerable<Task> LoadAllTasks(ICriteria criteria);
        IEnumerable<Match> GetSuspiciousMatches(string query);
        IEnumerable<SuspiciousInfo> GetSuspiciousTickets(string query);
        IEnumerable<TablesForeignKey> GetTablesForeignKey(ICriteria criteria);

        Task GetTaskInfoByTaskId(ICriteria criteria);

        /// <summary>
        ///     Return a list of ids.
        /// </summary>
        /// <param name="sqlQueryString">The query string.</param>
        /// <returns>List of ids.</returns>
        IEnumerable<string> ExecutePrecondition(string sqlQueryString);

        List<SuspiciousInfo> ExecuteRule(string sqlQueryString, int taskId, int workflowId);
        IEnumerable<T> GetData<T>(ICriteria criteria);
        IEnumerable<T> GetData<T>(dynamic paramaters);
        IEnumerable<T> GetData<T>(ICriteria criteria, ref int totalPages);

        /// <summary>
        ///     Execute Non Query Inline.
        /// </summary>
        /// <param name="sqlQueryString">Query string.</param>
        /// <returns>Command result.</returns>
        ICommandResult ExecuteNonQueryInline(string sqlQueryString);

        /// <summary>
        ///     Execute Reader Query Inline.
        /// </summary>
        /// <param name="sqlQueryString">Query string.</param>
        /// <returns>Data table.</returns>
        DataTable ExecuteReaderQueryInline(string sqlQueryString);

        IList<SuspiciousCustomer> GetSuspiciousCustomers(string sqlQueryString, int workflowId);
        IList<SuspiciousInfo> GetSuspiciousCustomerHistory(ICriteria criteria);
    }
}