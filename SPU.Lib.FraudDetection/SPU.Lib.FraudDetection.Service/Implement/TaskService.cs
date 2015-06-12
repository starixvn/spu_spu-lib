// --------------------------------------------------------------------------
// <copyright file="TaskService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
//   <change who="Thai.Tran" date="2015.05.21">Loading all active tasks.</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.Core;
    using SPU.Lib.FraudDetection.DataAccess.Implement;
    using SPU.Lib.FraudDetection.DataAccess.Interface;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.Service.Interface;

    /// <summary>
    /// Task Service.
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

        public ICommandResult InsertTask(ICriteria criteria)
        {
            return _taskDataAccess.InsertTask(criteria);
        }

        public ICommandResult DeleteTask(ICriteria criteria)
        {
            return _taskDataAccess.DeleteTask(criteria);
        }

        public DataCollection GetTasksByWorkflowId(ICriteria criteria)
        {
            return _taskDataAccess.GetTasksByWorkflowId(criteria);
        }

        public ICommandResult UpdateTask(ICriteria criteria)
        {
            return _taskDataAccess.UpdateTask(criteria);
        }

        public IEnumerable<TaskInfo> LoadAllTasks(ICriteria criteria)
        {
            return GetData<TaskInfo>(criteria);
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

        /// <summary>
        /// Collect Suspicious Info.
        /// </summary>
        /// <param name="sqlQueryString">Query string.</param>
        /// <returns>List of suspicious information.</returns>
        public IEnumerable<SuspiciousInfo> CollectSuspiciousInfo(string sqlQueryString)
        {
            var suspiciousInfoList = new List<SuspiciousInfo>();
            var suspiciousInfoDataTable = ExecuteReaderQueryInline(sqlQueryString);

            foreach (DataRow dataRow in suspiciousInfoDataTable.Rows)
            {
                suspiciousInfoList.Add(new SuspiciousInfo
                {
                    CustId = int.Parse(dataRow["custid"].ToString()),
                    MatchId = int.Parse(dataRow["matchid"].ToString()),
                    WorkflowId = string.IsNullOrEmpty(dataRow["workflowid"].ToString())
                                    ? 0
                                    : int.Parse(dataRow["workflowid"].ToString()),
                    TransIdList = dataRow["listtransid"].ToString()
                });
            }

            return suspiciousInfoList;
        }

        /// <summary>
        /// Return a list of ids.
        /// </summary>
        /// <param name="sqlQueryString">The query string.</param>
        /// <returns>List of ids.</returns>
        public IEnumerable<string> ExecutePrecondition(string sqlQueryString)
        {
            List<string> listOfIDs = new List<string>();
            DataTable dt = ExecuteReaderQueryInline(sqlQueryString);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listOfIDs.Add(dt.Rows[i][0].ToString());
            }

            return listOfIDs as IEnumerable<string>;
        }

        /// <summary>
        /// Execute Rule.
        /// </summary>
        /// <param name="sqlQueryString">SQL Query String.</param>
        /// <param name="workflowId">Workflow ID.</param>
        /// <returns>List of Suspicious Info.</returns>
        public List<SuspiciousInfo> ExecuteRule(string sqlQueryString, int workflowId)
        {
            List<SuspiciousInfo> suspiciousInfoList = new List<SuspiciousInfo>();
            DataTable dt = ExecuteReaderQueryInline(sqlQueryString);
            int custId = 0;
            int matchId = 0;
            long transId = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                custId = int.Parse(dt.Rows[i]["matchid"].ToString());
                matchId = int.Parse(dt.Rows[i]["custid"].ToString());
                transId = long.Parse(dt.Rows[i]["transid"].ToString());

                var currentInfo = suspiciousInfoList.Find(x => x.CustId == custId && x.MatchId == matchId && x.WorkflowId == workflowId);

                if (currentInfo == null)
                {
                    SuspiciousInfo info = new SuspiciousInfo();
                    info.WorkflowId = workflowId;
                    info.MatchId = matchId;
                    info.CustId = custId;
                    info.TransIdList = transId.ToString();

                    suspiciousInfoList.Add(info);
                }
                else
                {
                    suspiciousInfoList.Find(x => x.CustId == custId && x.MatchId == matchId && x.WorkflowId == workflowId).TransIdList += "," + transId;
                }
            }

            return suspiciousInfoList;
        }

        public void Dispose()
        {
        }
    }
}
