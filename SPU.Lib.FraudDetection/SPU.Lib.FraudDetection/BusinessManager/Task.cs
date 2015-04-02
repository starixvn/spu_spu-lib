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
                strCond = string.Join(" ", preCond.ConfigName, preCond.ConfigOperator, preCond.ConfigValue);
                sqlStr += string.Join(" AND ", strCond);
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
                strRule = string.Join(" ", rule.ConfigName, rule.ConfigOperator, rule.ConfigValue);
                sqlStr += string.Join(" AND ", strRule);
            }

            return sqlStr;
        }

        #endregion

        #region RunTask

        /// <summary>
        /// Execute a task.
        /// </summary>
        /// <param name="match">The match for scanning.</param>        
        public void Run(Match match)
        {
            try
            {
                if (CheckPreconditions(match))
                {
                    string rules = RetrieveRules(match);

                    List<SuspiciousInfo> suspiciousList = CollectSuspiciousInfo(rules);

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

        public List<SuspiciousInfo> CollectSuspiciousInfo(string rules)
        {
            TaskService taskService = new TaskService();
            ////taskService.ExecuteReaderQueryInline(sqlStr);
            IEnumerable<SuspiciousInfo> list = taskService.GetData<SuspiciousInfo>(null); ////todo

            return list.ToList();
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
