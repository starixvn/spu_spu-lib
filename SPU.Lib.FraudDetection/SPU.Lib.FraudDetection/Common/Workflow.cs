// --------------------------------------------------------------------------
// <copyright file="Workflow.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// Workflow Class.
    /// </summary>
    public class Workflow
    {
        #region Properties

        public int WorkflowId { get; set; }

        public string WorkflowName { get; set; }

        public string WorkflowDesc { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Methods

        public bool RunWorkflow()
        {
            return true;
        }

        public List<Task> GetTasks()
        {
            return null;
        }

        public bool AssignTaskToThreadPool(Task task)
        {
            return true;
        }

        #endregion
    }
}
