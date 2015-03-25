// --------------------------------------------------------------------------
// <copyright file="Task.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Controller
{
    using System.Collections.Generic;
    using SPU.Lib.FraudDetection.Criteria;

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

        public string TaskRules { get; set; }

        public int WorkflowId { get; set; }

        public bool IsRunMannually { get; set; }

        public int NextActionId { get; set; }

        public int Timer { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Methods

        public bool RunTask()
        {
            return true;
        }

        public bool CheckPreconditions()
        {
            return true;
        }
        
        public string BuildRules()
        {
            return string.Empty;
        }

        public List<SuspiciousInfo> GetSuspiciousInfo()
        {
            return null;
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
