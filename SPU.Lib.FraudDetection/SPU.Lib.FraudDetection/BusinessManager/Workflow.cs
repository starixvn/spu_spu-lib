// --------------------------------------------------------------------------
// <copyright file="Workflow.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
//   <change who="Long.Luu" date="2015.04.01">Modified: WorkflowInfo</change>
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
        #region Properties

        private List<TaskInfo> _tasksInfo = new List<TaskInfo>();

        private WorkflowService _workflowService = new WorkflowService();

        private WorkflowInfo _workflowInfo;

        #endregion        
        
        #region Constructor

        public Workflow(WorkflowInfo workflowInfo)
        {
            _workflowInfo = workflowInfo;
        }

        #endregion

        #region Execute Methods

        /// <summary>
        /// Execute a workflow for a match.
        /// </summary>
        /// <param name="match">The match scanned.</param>        
        public void Run(Match match)
        {
            foreach (TaskInfo taskInfo in GetTasks())
            {
                if (taskInfo.IsActive)
                {
                    var task = new Task(taskInfo);
                    if (task.TaskInfo.IsRunMannually)
                    {
                        task.Run(match);
                    }
                    else
                    {
                        AssignTaskToThreadPool(task, match);
                    }
                }
            }
        }

        public void AssignTaskToThreadPool(Task task, Match match)
        {
            ThreadPool.AddTask(task, delegate { task.Run(match); });
        }
     
        #endregion

        #region Task Methods
       
        public List<TaskInfo> GetTasks()
        {
            if (_tasksInfo.Count == 0)
            {
                IEnumerable<TaskInfo> tasks = _workflowService.GetTasks(new TaskSelectAllByWorkflowIdCriteria());
                _tasksInfo = tasks.ToList();
            }

            return _tasksInfo;
        }

        public void InsertTask(TaskInfo task)
        {
            _tasksInfo.Add(task);            
        }

        public void RemoveTask(TaskInfo task)
        {
            _tasksInfo.Remove(task);
        }       

        #endregion     
    }
}
