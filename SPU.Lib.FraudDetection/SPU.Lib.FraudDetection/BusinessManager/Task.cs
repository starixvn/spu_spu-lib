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
    using System.Timers;
    using Core;
    using DTO;
    using NextAction;
    using Service.Implement;
    using Service.Interface;

    /// <summary>
    /// Task Class.
    /// </summary>
    public class Task
    {
        #region Constructor

        public Task()
        {
        }

        public Task(TaskInfo taskInfo)
        {
            TaskInfo = taskInfo;
        }

        #endregion Constructor

        #region Properties

        public TaskInfo TaskInfo { get; set; }

        public string IdsList { get; set; }

        public List<SuspiciousInfo> SuspiciousInfoList { get; set; }

        public string TaskCode
        {
            get { return string.Format("{0}-{1}", TaskInfo.WorkflowId, TaskInfo.TaskId); }
        }

        #endregion Properties

        #region BuildTask

        /// <summary>
        /// Build the precondition for a task.
        /// </summary>
        /// <returns>The precondition string.</returns>
        public string BuildPreconditions()
        {
            var sqlStr = string.Empty;

            foreach (var preCond in TaskInfo.Preconditions)
            {
                // TO DO
                // strCond = string.Join(" ", preCond.ConfigName, preCond.ConfigOperator, preCond.ConfigValue);
                // sqlStr += string.Join(" AND ", strCond);
            }

            return sqlStr;
        }

        /// <summary>
        /// Build the rule for a task.
        /// </summary>
        /// <returns>The rule string.</returns>
        public string BuildRules()
        {
            var sqlStr = string.Empty;

            foreach (var rule in TaskInfo.Rules)
            {
                // TO DO
                // strRule = string.Join(" ", rule.ConfigName, rule.ConfigOperator, rule.ConfigValue);
                // sqlStr += string.Join(" AND ", strRule);
            }

            return sqlStr;
        }

        #endregion BuildTask

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
                    ITaskService taskService = new TaskService();

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
            var sqlStr = string.Join("select top 1 matchid from matches where matchid = ", match.MatchId, " and ", TaskInfo.Preconditions);

            ITaskService taskService = new TaskService();
            return taskService.ExecuteReaderQueryInline(sqlStr).Rows.Count > 0;
        }

        public string RetrieveRules(Match match)
        {
            return string.Join("select * from bettrans where matchid = ", match.MatchId, " and ", TaskInfo.TaskRules);
        }

        #endregion RunTask

        #region Scan

        /// <summary>
        /// Scan suspicious tickets.
        /// </summary>
        /// <param name="source">Source object.</param>
        /// <param name="e">Elapsed Event Arguments.</param>
        public void Scan(object source, ElapsedEventArgs e)
        {
            try
            {
                if (TaskInfo.IsActive)
                {
                    var preConGroups = ExecutePrecondition();
                    if (preConGroups != null)
                    {
                        SuspiciousInfoList = ExecuteRule(preConGroups);
                    }

                    if (TaskInfo.EventId == 1)
                    {
                        var saveAction = new ActionSaveSuspiciousInfo(SuspiciousInfoList, IdsList, TaskInfo.WorkflowId);
                        saveAction.TakeAction();
                    }

                    TakeNextAction(SuspiciousInfoList);
                }
            }
            catch (Exception ex)
            {
                Fanex.Logging.Logger.Log.Error("Scan : " + ex.Message);
            }
        }

        /// <summary>
        /// Execute the precondition of task.
        /// </summary>
        /// <returns>List of ids.</returns>
        private IEnumerable<IEnumerable<string>> ExecutePrecondition()
        {
            try
            {
                var preConditionQuery = string.Empty;
                IEnumerable<IEnumerable<string>> preConGroups = null;

                if (!string.IsNullOrEmpty(TaskInfo.TaskPreconditions))
                {
                    using (var taskService = new TaskService())
                    {
                        preConditionQuery = TaskInfo.TaskPreconditions.Replace("\r\n", " ").Replace("$param1$", TaskInfo.WorkflowId.ToString());
                        var preConResult = taskService.ExecutePrecondition(preConditionQuery);
                        IdsList = string.Join(";", preConResult);
                        preConGroups = preConResult.Chunk<string>(5); // split into groups of 5 items due to the performance when querying
                    }
                }

                return preConGroups;
            }
            catch (Exception ex)
            {
                Fanex.Logging.Logger.Log.Error("ExecutePrecondition : " + ex);
            }

            return new List<IEnumerable<string>> ();
        }

        /// <summary>
        ///  Execute the rule of task.
        /// </summary>
        /// <param name="preConGroups">The retrieved list of ids from precondition.</param>
        /// <returns>List of suspicious info.</returns>
        private List<SuspiciousInfo> ExecuteRule(IEnumerable<IEnumerable<string>> preConGroups)
        {
            try
            {
                var ruleQuery = string.Empty;
                var suspiciousTickets = new List<SuspiciousInfo>();

                using (var taskService = new TaskService())
                {
                    if (preConGroups != null)
                    {
                        foreach (IEnumerable<string> group in preConGroups)
                        {
                            ruleQuery = TaskInfo.TaskRules.Replace("\r\n", " ").Replace("$param1$", string.Join(",", group));
                            suspiciousTickets.AddRange(taskService.ExecuteRule(ruleQuery, TaskInfo.WorkflowId));
                        }
                    }
                }

                return suspiciousTickets;
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }

            return new List<SuspiciousInfo>();
        }

        /// <summary>
        /// Do next action for the task.
        /// </summary>
        /// <param name="suspiciousInfoList">List of suspicious tickets.</param>
        private void TakeNextAction(List<SuspiciousInfo> suspiciousInfoList)
        {
            try
            {
                if (suspiciousInfoList.Count > 0)
                {
                    var nextActionIdList = TaskInfo.NextActionIdList.Split(',');
                    var nextActionTargetIdList = TaskInfo.NextActionTargetIdList.Split(',');

                    
                    for (var i = 0; i < nextActionIdList.Count(); i++)
                    {
                        var nextAction = ActionFactory.GetAction(
                                                                            short.Parse(nextActionIdList[i]),
                                                                            int.Parse(nextActionTargetIdList[i]),
                                                                            suspiciousInfoList);
                        nextAction.TakeAction();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        private void WriteLog(Exception exception)
        {
            var message = "\r\nError:" + exception.Message +
                          "\r\nStackTrace: " + exception.StackTrace;

            Fanex.Logging.Logger.Log.Error(message);
        }

        #endregion Scan
    }
}