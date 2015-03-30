// --------------------------------------------------------------------------
// <copyright file="Task.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager
{
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
        #region Properties

        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string TaskDesc { get; set; }

        public string TaskPreconditions { get; set; }

        public List<Config> Preconditions { get; set; }

        public string TaskRules { get; set; }

        public List<Config> Rules { get; set; }

        public int WorkflowId { get; set; }

        public bool IsRunMannually { get; set; }

        public string NextActionIdList { get; set; }

        public int Timer { get; set; }

        public bool IsActive { get; set; }

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

            foreach (var preCond in Preconditions)
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

            foreach (var rule in Rules)
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
        /// <returns>True if success.</returns>
        public bool Run(Match match)
        {
            bool result = false;
            
            if (CheckPreconditions(match))
            {
                string rules = RetrieveRules(match);

                List<SuspiciousInfo> suspiciousList = CollectSuspiciousInfo(rules);

                result = StoreSuspiciousInfo(suspiciousList);
                result = result & TakeNextAction(suspiciousList);
            }

            return result;
        }

        public bool CheckPreconditions(Match match)
        {
            string sqlStr = string.Join("select top 1 matchid from matches where matchid = ", match.MatchId, " and ", TaskPreconditions);

            TaskService taskService = new TaskService();
            IEnumerable<Match> list = taskService.GetData<Match>(null); ////todo
            return list.Count() > 0;            
        }

        public string RetrieveRules(Match match)
        {
            return string.Join("select * from bettrans where matchid = ", match.MatchId, " and ", TaskRules); ////todo
        }

        public List<SuspiciousInfo> CollectSuspiciousInfo(string rules)
        {                        
            TaskService taskService = new TaskService();
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
            foreach (var actionId in NextActionIdList.Split(','))
            {
                BaseAction nextAction = ActionFactory.GetAction(short.Parse(actionId));
                nextAction.TakeAction();
            }

            return true;
        }

        #endregion
    }
}
