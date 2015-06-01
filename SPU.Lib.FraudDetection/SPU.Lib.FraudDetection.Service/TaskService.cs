// --------------------------------------------------------------------------
// <copyright file="TaskService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
//   <change who="Thai.Tran" date="2015.05.21">Loading all active tasks.</change>
// </history>

namespace SPU.Lib.FraudDetection.Service
{
    using System.Collections.Generic;
    using System.Data;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DataAccess;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.Core;

    /// <summary>
    /// Task Service.
    /// </summary>
    public class TaskService : QueryService, System.IDisposable
    {
        private TaskDataAccess _taskDataAccess;

        public TaskService()
        {
            _taskDataAccess = new TaskDataAccess();
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
            List<string> IdList = new List<string>();
            DataTable dt = ExecuteReaderQueryInline(sqlQueryString);

            for(int i =0;i< dt.Rows.Count ; i++)
            {
                IdList.Add(dt.Rows[i][0].ToString());
            }

            return IdList as IEnumerable<string>;
        }

        public List<SuspiciousInfo> ExecuteRule(string sqlQueryString, int workflowId)
        {
            List<SuspiciousInfo> suspiciousInfoList = new List<SuspiciousInfo>();
            DataTable dt = ExecuteReaderQueryInline(sqlQueryString);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SuspiciousInfo info = new SuspiciousInfo();
                info.WorkflowId = workflowId;
                info.MatchId =int.Parse(dt.Rows[i]["matchid"].ToString());
                info.CustId = int.Parse(dt.Rows[i]["custid"].ToString());
                info.TransIdList = dt.Rows[i]["transidList"].ToString();

                if (suspiciousInfoList.Find(x => x.CustId == info.CustId && x.MatchId == info.MatchId) == null) //todo: will be remove after Long taks.
                {
                    suspiciousInfoList.Add(info);
                }
            }

            return suspiciousInfoList;
        }

        void System.IDisposable.Dispose()
        {

        }
    }
}
