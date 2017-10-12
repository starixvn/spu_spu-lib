// --------------------------------------------------------------------------
// <copyright file="ITaskService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Core.Utilities;
    using Criteria.Task;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    ///     Task Service interface.
    /// </summary>
    public interface ITaskService
    {
        ICommandResult InsertTask(ICriteria criteria);

        ICommandResult DeleteTask(ICriteria criteria);

        bool CheckAllTicketsSettled(int matchId, string bettypeIds);

        DataCollection GetTasksByCaseId(TaskGetAllByCaseIdCriteria criteria);

        IEnumerable<Task> GetTasksByCaseId(TaskGetByCaseIdCriteria criteria);

        IEnumerable<Task> GetBackGroundTasksByCase(TaskBackGroundGetByCaseIdCriteria criteria);

        ICommandResult UpdateTask(ICriteria criteria);

        IEnumerable<Task> LoadAllTasks(ICriteria criteria);

        IEnumerable<Match> GetSuspiciousMatches(string query);

        IEnumerable<SuspiciousInfo> GetSuspiciousTickets(string query);

        IEnumerable<TablesForeignKey> GetTablesForeignKey(ICriteria criteria);

        Task GetTaskInfoByTaskId(ICriteria criteria);

        Task GetTaskForExecuting(ICriteria criteria);

        IEnumerable<Task> GetTaskForTriggering(ICriteria criteria);

        IEnumerable<Match> ExecutePrecondition(string sqlQueryString);

        IEnumerable<string> ExecutePreconditionForCountingSuspiciousTimes(string sqlQueryString);

        List<SuspiciousInfo> ExecuteRule(string sqlQueryString, int taskId, int caseId, DateTime eventDate);

        IEnumerable<T> GetData<T>(ICriteria criteria);

        IEnumerable<T> GetData<T>(dynamic paramaters);

        IEnumerable<T> GetData<T>(ICriteria criteria, ref int totalPages);

        ICommandResult ExecuteNonQueryInline(string sqlQueryString);

        DataTable ExecuteReaderQueryInline(string sqlQueryString);

        IList<SuspiciousCustomer> GetSuspiciousCustomers(string sqlQueryString, int caseId);

        IList<SuspiciousInfo> GetSuspiciousCustomerHistory(ICriteria criteria);

        List<SuspiciousGroupInfo> ExecuteRuleForGrouping(string sqlQueryString, int taskId, int caseId);

        List<string> ExecuteRuleForCapturingData(string sqlQueryString);

        List<DataCapture> ExecuteRuleForComparingData(string sqlQueryString);

        decimal CaptureData(string sqlQueryString);

        IEnumerable<Customer> ExecutePreconditionForSyncDataWithFPS(string sqlQueryString);
    }
}