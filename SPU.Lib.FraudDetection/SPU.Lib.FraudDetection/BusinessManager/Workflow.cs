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

        #region Execute Methods

        /// <summary>
        /// Execute a workflow for a match.
        /// </summary>
        /// <param name="match">The match scanned.</param>        
        public void Run(Match match)
        {
            foreach (Task task in GetTasks())
            {
                if (task.IsRunMannually)
                {
                    task.Run(match);
                }
                else
                {
                    AssignTaskToThreadPool(task, match);
                }
            }
        }

        public void AssignTaskToThreadPool(Task task, Match match)
        {
            ThreadPool.AddTask(task, delegate { task.Run(match); });
        }
     
        #endregion

        #region Task Methods
       
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

        #endregion     
    }
}
