// --------------------------------------------------------------------------
// <copyright file="Workflow.cs" company="Nexcel Solutions Vietnam">
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
    using SPU.Lib.FraudDetection.Criteria.Taks;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.Service;

    /// <summary>
    /// Workflow Class.
    /// </summary>
    public class Workflow
    {
        private List<Task> _tasks = new List<Task>();

        private WorkflowService _workflowService = new WorkflowService();

        #region Properties

        public int WorkflowId { get; set; }

        public string WorkflowName { get; set; }

        public string WorkflowDesc { get; set; }

        public bool IsActive { get; set; }      

        #endregion        

        #region Task Methods

        /// <summary>
        /// Execute a workflow for a match.
        /// </summary>
        /// <param name="match">The match scanned.</param>
        /// <returns>True if execute tasks in the workflow is success.</returns>
        public bool Run(Match match)
        {
            bool result = true;
            
            foreach (Task task in GetTasks())
            {
                if (task.IsRunMannually)
                {
                    result = result & task.Run(match);
                }
                else
                {
                    result = result & AssignTaskToThreadPool(task);
                }
            }

            return result;
        }

        public List<Task> GetTasks()
        {
            if (_tasks.Count == 0)
            {
                IEnumerable<Task> tasks = _workflowService.GetData<Task>(new TaskSelectAllByWorkflowIdCriteria());
                _tasks = tasks.ToList();
            }

            return _tasks;
        }

        public void InsertTask(Task task)
        {
            _tasks.Add(task);            
        }

        public void RemoveTask(Task task)
        {
            _tasks.Remove(task);
        }

        public bool AssignTaskToThreadPool(Task task)
        {
            return true;
        }

        #endregion     
    }
}
