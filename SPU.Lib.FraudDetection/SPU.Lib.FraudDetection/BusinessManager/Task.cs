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
    using SPU.Lib.FraudDetection.BusinessObject;
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

        public int NextActionId { get; set; }

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
        /// Execute a taks.
        /// </summary>
        /// <param name="match">The match for scanning.</param>
        /// <returns>True if success.</returns>
        public bool Run(Match match)
        {
            bool result = false;
            
            if (CheckPreconditions(match))
            {
                string rules = GetRules();

                List<SuspiciousInfo> suspiciousList = GetSuspiciousInfo(rules);

                result = StoreDatabase(suspiciousList);
                result = result & TakeNextAction(suspiciousList);
            }

            return result;
        }

        public bool CheckPreconditions(Match match)
        {
            string sqlStr = string.Join("select * from matches where match.id = ", match.MatchId, " and ", TaskPreconditions);

            QueryService queryService = new QueryService();            
            IEnumerable<Match> list = queryService.GetData<Match>(null);
            return list.Count() > 0;            
        }

        public string GetRules()
        {
            return "select * from bettrans where " + TaskRules;            
        }

        public List<SuspiciousInfo> GetSuspiciousInfo(string rules)
        {
            QueryService queryService = new QueryService();
            IEnumerable<SuspiciousInfo> list = queryService.GetData<SuspiciousInfo>(null);

            return list.ToList();
        }

        public bool TakeNextAction(List<SuspiciousInfo> listSuspiciousInfo)
        {
            return true;
        }

        public bool StoreDatabase(List<SuspiciousInfo> listSuspiciousInfo)
        {
            return true;
        }     
        #endregion
    }
}
