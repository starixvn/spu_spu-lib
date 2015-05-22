// --------------------------------------------------------------------------
// <copyright file="Task.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
//   <change who="Long.Luu" date="2015.04.01">Modified: TaskInfo</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SPU.Lib.FraudDetection.Criteria;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.Service;
    using SPU.Lib.Core;
    using System.Threading;
    using System.Collections;

    /// <summary>
    /// Task Class.
    /// </summary>
    public class Task
    {
        #region Constructor

        public Task(TaskInfo taskInfo)
        {
            this.TaskInfo = taskInfo;
        }

        #endregion

        #region Properties

        public TaskInfo TaskInfo { get; set; }

        #endregion
        
        #region BuildTask

        /// <summary>
        /// Build the precondition for a task.
        /// </summary>
        /// <returns>The precondition string.</returns>
        public string BuildPreconditions()
        {
            string sqlStr = string.Empty;
            string strCond = string.Empty;

            foreach (var preCond in TaskInfo.Preconditions)
            {
                // TO DO
                //strCond = string.Join(" ", preCond.ConfigName, preCond.ConfigOperator, preCond.ConfigValue);
                //sqlStr += string.Join(" AND ", strCond);
            }

            return sqlStr;
        }

        /// <summary>
        /// Build the rule for a task.
        /// </summary>
        /// <returns>The rule string.</returns>
        public string BuildRules()
        {
            string sqlStr = string.Empty;
            string strRule = string.Empty;

            foreach (var rule in TaskInfo.Rules)
            {
                // TO DO
                //strRule = string.Join(" ", rule.ConfigName, rule.ConfigOperator, rule.ConfigValue);
                //sqlStr += string.Join(" AND ", strRule);
            }

            return sqlStr;
        }

        #endregion

        #region RunTask

        /// <summary>
        /// Execute a task for a suspicious match.
        /// </summary>
        /// <param name="match">The match for scanning.</param>        
        public void Run(Match match)
        {
            try
            {
                if (CheckPreconditions(match))
                {
                    string rules = RetrieveRules(match);

                    List<SuspiciousInfo> suspiciousList = CollectSuspiciousTickets(rules);

                    StoreSuspiciousInfo(suspiciousList);
                    TakeNextAction(suspiciousList);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Task Run -- " + ex.Message);
            }
        }

        public bool CheckPreconditions(Match match)
        {
            string sqlStr = string.Join("select top 1 matchid from matches where matchid = ", match.MatchId, " and ", TaskInfo.Preconditions);

            TaskService taskService = new TaskService();
            return taskService.ExecuteReaderQueryInline(sqlStr).Rows.Count > 0;
        }

        public string RetrieveRules(Match match)
        {
            return string.Join("select * from bettrans where matchid = ", match.MatchId, " and ", TaskInfo.TaskRules); ////todo
        }
       
        #endregion

        #region Scan

        static Barrier barrier = new Barrier(2, (b) => { });
        

        /// <summary>
        /// Scan suspicious tickets.
        /// </summary>        
        public void Scan()
        {
            try
            {                
                if (TaskInfo.IsActive)
                {
                    //IEnumerable<Match> suspiciousMatches = CollectSuspiciousMatches(TaskInfo.TaskPreconditions); //todo

                    ////split matches into groups of 5 matches then collect synchronouslly suspicious tickets of each group
                    //var suspiciousMatchGroups = suspiciousMatches.Chunk<Match>(5);
                    
                    //string query = TaskInfo.TaskQuery.Replace("@Matches", "");//todo
                    //List<SuspiciousInfo> suspiciousTickets = CollectSuspiciousTickets(query); //todo
                    //StoreSuspiciousInfo(suspiciousTickets);
                    //TakeNextAction(suspiciousTickets);
        
                    ////barrier.SignalAndWait(

                    //var t1 = new System.Threading.Tasks.Task(() => Console.WriteLine("Completed t1"));
                    
                    //t1.ContinueWith(task1 => {
                    //        var t2 = new System.Threading.Tasks.Task(() => Console.WriteLine("Completed t1"));    
                    //        t2.Start(); 
                    //    });
                    //t1.Start();

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\spu_" + TaskInfo.TaskName + ".txt", true))
                    {
                        file.WriteLine(TaskInfo.TaskName + " -timer = " + DateTime.Now.ToLongTimeString() );
                    }                    
                }

                Thread.Sleep(TaskInfo.Interval);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Task Scanning -- " + ex.Message);
            }
        }

        private IEnumerable<dynamic> ExecutePreCondition(string query)
        {
            using (TaskService taskService = new TaskService())
            {
                return taskService.GetData<dynamic>(query);
            }
        }

        public IEnumerable<Match> CollectSuspiciousMatches(string query)
        {
            using (TaskService taskService = new TaskService())
            {
                return taskService.GetSuspiciousMatches(query);
            }
        }

        /// <summary>
        /// Collect suspicious tickets.
        /// </summary>
        /// <param name="query">The query string.</param>
        /// <returns>List of suspicious tickets.</returns>
        public List<SuspiciousInfo> CollectSuspiciousTickets(string query)
        {
            using (TaskService taskService = new TaskService())
            {
                return taskService.GetSuspiciousTickets(query).ToList();
            }
        }

        /// <summary>
        /// Save suspicious info list.
        /// </summary>
        /// <param name="listSuspiciousInfo">The suspicious info list.</param>
        /// <returns>True if success.</returns>
        public bool StoreSuspiciousInfo(List<SuspiciousInfo> listSuspiciousInfo)
        {
            SuspiciousInfoService suspiciousInfoService = new SuspiciousInfoService();

            SuspiciousInfoInsertCriteria criteria = new SuspiciousInfoInsertCriteria();

            string custIdList = string.Empty;
            string matchIdList = string.Empty;
            string workflowIdList = string.Empty;
            string groupTransIdList = string.Empty;

            foreach (var info in listSuspiciousInfo)
            {
                custIdList = string.Join(";", custIdList, info.CustId);
                matchIdList = string.Join(";", matchIdList, info.MatchId);
                workflowIdList = string.Join(";", workflowIdList, info.WorkflowId);
                groupTransIdList = string.Join(";", groupTransIdList, info.ListTransId);
            }

            criteria.CustIdList = custIdList;
            criteria.MatchIdList = matchIdList;
            criteria.WorkflowIdList = workflowIdList;
            criteria.GroupTransIdList = groupTransIdList;

            return suspiciousInfoService.InsertSuspiciousInfo(criteria).IsSuccessful;
        }

        /// <summary>
        /// Do next action for the task.
        /// </summary>
        /// <param name="listSuspiciousInfo">List of suspicious tickets.</param>
        /// <returns>True if success.</returns>
        public bool TakeNextAction(List<SuspiciousInfo> listSuspiciousInfo)
        {
            foreach (var actionId in TaskInfo.NextActionIdList.Split(','))
            {
                BaseAction nextAction = ActionFactory.GetAction(short.Parse(actionId));
                nextAction.TakeAction();
            }

            return true;
        }

        #endregion
    }
}
