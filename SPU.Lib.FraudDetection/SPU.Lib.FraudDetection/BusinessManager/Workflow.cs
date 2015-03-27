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
    using SPU.Lib.FraudDetection.Service;
    using SPU.Lib.FraudDetection.Criteria.Taks;
    using System.Linq;
using SPU.Lib.FraudDetection.Criteria.Workflow;

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

        private List<Task> _tasks = new List<Task>();

        private ConfigurationsService _workflowService = new ConfigurationsService();

        #endregion

        #region Methods

        public bool RunWorkflow()
        {
            return true;
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
