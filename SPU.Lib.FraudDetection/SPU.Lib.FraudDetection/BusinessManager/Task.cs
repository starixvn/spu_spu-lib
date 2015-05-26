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
                    TaskService taskService = new TaskService();

                    string rules = RetrieveRules(match);

                    List<SuspiciousInfo> suspiciousList = taskService.GetData<SuspiciousInfo>(rules).ToList();
                    
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
        
        /// <summary>
        /// Scan suspicious tickets.
        /// </summary>        
        public void Scan()
        {
            try
            {                
                if (TaskInfo.IsActive)
                {                    
                    IEnumerable<IEnumerable<string>> preConGroups = ExecutePrecondition();

                    List<SuspiciousInfo> suspiciousTickets = ExecuteRule(preConGroups);

                    if (TaskInfo.ActionId == 1)
                    {
                        var saveAction = new ActionSaveSuspiciousInfo(suspiciousTickets);
                        saveAction.TakeAction();
                    }

                    TakeNextAction(suspiciousTickets);                 

                    //var t1 = new System.Threading.Tasks.Task(() => Console.WriteLine("Completed t1"));

                    //t1.ContinueWith(task1 =>
                    //{
                    //    var t2 = new System.Threading.Tasks.Task(() => Console.WriteLine("Completed t1"));
                    //    t2.Start();
                    //});
                    //t1.Start();

                    //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\spu_" + TaskInfo.TaskName + ".txt", true))
                    //{
                    //    file.WriteLine(TaskInfo.TaskName + " -timer = " + DateTime.Now.ToLongTimeString() );
                    //}                    
                }

                Thread.Sleep(TaskInfo.Interval);//todo convert into milisecond.
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Task Scanning -- " + ex.Message);
            }
        }

        /// <summary>
        /// Execute the precondition of task.
        /// </summary>        
        /// <returns>List of ids.</returns>
        private IEnumerable<IEnumerable<string>> ExecutePrecondition()
        {                         
            IEnumerable<IEnumerable<string>> preConGroups = null;
            if (!string.IsNullOrEmpty(TaskInfo.TaskPreconditions))
            {
                using (TaskService taskService = new TaskService())
                {
                    IEnumerable<string> preConResult = taskService.GetData<string>(TaskInfo.TaskPreconditions);
                    preConGroups = preConResult.Chunk<string>(5); // split into groups of 5 items due to the performance when querying
                }
            }
            return preConGroups;
        }

        /// <summary>
        ///  Execute the rule of task.
        /// </summary>
        /// <param name="preConGroups">The retrieved list of ids from precondition.</param>
        /// <returns>List of suspicious info.</returns>
        private List<SuspiciousInfo> ExecuteRule(IEnumerable<IEnumerable<string>> preConGroups)
        {            
            string ruleQuery = string.Empty;
            List<SuspiciousInfo> suspiciousTickets = new List<SuspiciousInfo>();

            using (TaskService taskService = new TaskService())
            {
                if (preConGroups != null)
                {
                    foreach (IEnumerable<string> group in preConGroups)
                    {
                        ruleQuery = TaskInfo.TaskRules.Replace("@Params", string.Join(",", group));
                        suspiciousTickets.AddRange(taskService.GetData<SuspiciousInfo>(ruleQuery));
                    }
                }
                else
                {
                    ruleQuery = TaskInfo.TaskRules;
                    suspiciousTickets.AddRange(taskService.GetData<SuspiciousInfo>(ruleQuery));
                }
            }

            return suspiciousTickets;
        }
      
        /// <summary>
        /// Do next action for the task.
        /// </summary>
        /// <param name="listSuspiciousInfo">List of suspicious tickets.</param>
        /// <returns>True if success.</returns>
        private void TakeNextAction(List<SuspiciousInfo> listSuspiciousInfo)
        {
            if (listSuspiciousInfo.Count > 0)
            {
                foreach (var actionId in TaskInfo.NextActionIdList.Split(','))
                {
                    BaseAction nextAction = ActionFactory.GetAction(short.Parse(actionId), listSuspiciousInfo);
                    nextAction.TakeAction();
                }
            }            
        }

        #endregion
    }
}
