// --------------------------------------------------------------------------
// <copyright file="TaskService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
//   <change who="Thai.Tran" date="2015.05.21">Loading all active tasks.</change>
// </history>

namespace FD.Lib.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Core.Utilities;
    using Criteria.Task;
    using DataAccess.Implement;
    using DataAccess.Interface;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     Task Service.
    /// </summary>
    public class TaskService : QueryService, IDisposable, ITaskService
    {
        private readonly ITaskDataAccess _taskDataAccess;

        public TaskService()
        {
            _taskDataAccess = new TaskDataAccess();
        }

        public TaskService(ITaskDataAccess dataAccess)
        {
            _taskDataAccess = dataAccess;
        }

        public void Dispose()
        {
        }

        public ICommandResult InsertTask(ICriteria criteria)
        {
            return _taskDataAccess.InsertTask(criteria);
        }

        public ICommandResult DeleteTask(ICriteria criteria)
        {
            return _taskDataAccess.DeleteTask(criteria);
        }

        public DataCollection GetTasksByCaseId(TaskGetAllByCaseIdCriteria criteria)
        {
            return _taskDataAccess.GetTasksByCaseId(criteria);
        }

        public IEnumerable<Task> GetTasksByCaseId(TaskGetByCaseIdCriteria criteria)
        {
            return GetData<Task>(criteria);
        }

        public ICommandResult UpdateTask(ICriteria criteria)
        {
            return _taskDataAccess.UpdateTask(criteria);
        }

        public IEnumerable<Task> LoadAllTasks(ICriteria criteria)
        {
            return GetData<Task>(criteria);
        }

        public IEnumerable<Match> GetSuspiciousMatches(string query)
        {
            return GetData<Match>(query);
        }

        public IEnumerable<SuspiciousInfo> GetSuspiciousTickets(string query)
        {
            return GetData<SuspiciousInfo>(query);
        }

        public IEnumerable<TablesForeignKey> GetTablesForeignKey(ICriteria criteria)
        {
            return GetData<TablesForeignKey>(criteria);
        }

        public Task GetTaskInfoByTaskId(ICriteria criteria)
        {
            return Get<Task>(criteria);
        }

        public Task GetTaskForExecuting(ICriteria criteria)
        {
            return Get<Task>(criteria);
        }

        public IEnumerable<SuspiciousInfo> CollectSuspiciousInfo(string sqlQueryString)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Return a list of ids.
        /// </summary>
        /// <param name="sqlQueryString">The query string.</param>
        /// <returns>List of ids.</returns>
        public IEnumerable<string> ExecutePrecondition(string sqlQueryString)
        {
            var listOfIDs = new List<string>();

            var dt = ExecuteReaderQueryInline(sqlQueryString);

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                listOfIDs.Add(dt.Rows[i][0].ToString());
            }

            return listOfIDs;
        }

        /// <summary>
        ///     Execute Rule.
        /// </summary>
        /// <param name="sqlQueryString">SQL Query String.</param>
        /// <param name="taskId">Parameter Task ID.</param>
        /// <param name="caseId">Parameter Case ID.</param>
        /// <returns>List of Suspicious Info.</returns>
        public List<SuspiciousInfo> ExecuteRule(string sqlQueryString, int taskId, int caseId)
        {
            var suspiciousInfoList = new List<SuspiciousInfo>();

            var dt = ExecuteReaderQueryInline(sqlQueryString);

            var customerList = new List<dynamic>();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                customerList.Add(new
                {
                    CustId = int.Parse(dt.Rows[i]["custid"].ToString()),
                    MatchId = int.Parse(dt.Rows[i]["matchid"].ToString()),
                    TransId = long.Parse(dt.Rows[i]["transid"].ToString())
                });
            }

            var groups = customerList.GroupBy(t => new { t.CustId, t.MatchId });

            foreach (var group in groups)
            {
                var suspicion = new SuspiciousInfo
                {
                    CustId = group.Key.CustId,
                    MatchId = group.Key.MatchId,
                    TransId = string.Join(",", group.Select(t => t.TransId)),
                    CaseId = caseId,
                    TaskId = taskId
                };

                suspiciousInfoList.Add(suspicion);
            }

            return suspiciousInfoList;
        }

        /// <summary>
        ///     Execute Rule.
        /// </summary>
        /// <param name="sqlQueryString">SQL Query String.</param>
        /// <param name="taskId">Parameter Task ID.</param>
        /// <param name="caseId">Parameter Case ID.</param>
        /// <returns>List of Suspicious Info.</returns>
        public List<SuspiciousGroupInfo> ExecuteRuleForGrouping(string sqlQueryString, int taskId, int caseId)
        {
            var suspiciousInfoList = new List<SuspiciousGroupInfo>();

            var dt = ExecuteReaderQueryInline(sqlQueryString);

            var customerList = new List<dynamic>();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                customerList.Add(new
                {
                    CustId = int.Parse(dt.Rows[i]["custid"].ToString()),
                    MatchId = int.Parse(dt.Rows[i]["matchid"].ToString()),
                    TransId = long.Parse(dt.Rows[i]["transid"].ToString()),
                    Currency = int.Parse(dt.Rows[i]["currency"].ToString()),
                    CurrencyName = dt.Rows[i]["currencyname"].ToString(),
                    GroupingOption = dt.Rows[i]["groupby"].ToString()
                });
            }

            var groups = customerList.GroupBy(t => new { t.MatchId, t.CustId, t.Currency, t.CurrencyName, t.GroupingOption });

            foreach (var group in groups)
            {
                var suspiciousGroup = new SuspiciousGroupInfo
                {
                    MatchId = group.Key.MatchId,
                    GroupingOption = group.Key.GroupingOption,
                    CustId = group.Key.CustId,
                    TransId = string.Join(",", group.Select(t => t.TransId)),
                    CaseId = caseId,
                    TaskId = taskId,
                    Currency = group.Key.Currency,
                    CurrencyName = group.Key.CurrencyName
                };

                suspiciousInfoList.Add(suspiciousGroup);
            }

            return suspiciousInfoList;
        }

        public List<string> ExecuteRuleForCapturingData(string sqlQueryString)
        {
            var dt = ExecuteReaderQueryInline(sqlQueryString);

            var ticketList = new List<string>();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                ticketList.Add(dt.Rows[i]["transid"].ToString());
            }

            return ticketList;
        }

        public IList<SuspiciousCustomer> GetSuspiciousCustomers(string sqlQueryString, int taskId)
        {
            var suspiciousCustomers = new List<SuspiciousCustomer>();

            var dt = ExecuteReaderQueryInline(sqlQueryString);

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                suspiciousCustomers.Add(new SuspiciousCustomer
                {
                    CustId = int.Parse(dt.Rows[i]["custid"].ToString()),
                    TaskId = taskId
                });
            }

            return suspiciousCustomers;
        }

        public IList<SuspiciousInfo> GetSuspiciousCustomerHistory(ICriteria criteria)
        {
            return GetData<SuspiciousInfo>(criteria).ToList();
        }

        public List<DataTypeCapture> GetAllDataTypeCapture(ICriteria criteria)
        {
            return GetData<DataTypeCapture>(criteria).ToList();
        }

        public decimal CaptureData(string sqlQueryString)
        {
            var dt = ExecuteReaderQueryInline(sqlQueryString);
            var result = decimal.Parse(dt.Rows[0]["DataCapture"].ToString(), CultureInfo.InvariantCulture);

            return result;
        }
    }
}