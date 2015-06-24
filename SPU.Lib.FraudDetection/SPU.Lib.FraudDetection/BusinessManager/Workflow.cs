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
    using Criteria.Task;
    using DTO;
    using Service.Implement;
    using Service.Interface;

    /// <summary>
    ///     Workflow Class.
    /// </summary>
    public class Workflow
    {
        #region Properties

        private List<Task> _tasksInfo = new List<Task>();

        private readonly IWorkflowService _workflowService = new WorkflowService();

        private readonly WorkflowInfo _workflowInfo;

        #endregion Properties

        #region Constructor

        public Workflow(WorkflowInfo workflowInfo)
        {
            _workflowInfo = workflowInfo;
            ThreadPool = new TaskManager();
        }

        public TaskManager ThreadPool { get; set; }

        #endregion Constructor

        #region Task Methods

        public List<Task> GetTasks()
        {
            if (_tasksInfo.Count == 0)
            {
                var criteria = new TaskSelectAllByWorkflowIdCriteria {WorkFlowId = _workflowInfo.WorkflowId};
                var tasks = _workflowService.GetTasks(criteria);
                _tasksInfo = tasks.ToList();
            }

            return _tasksInfo;
        }

        public void InsertTask(Task task)
        {
            _tasksInfo.Add(task);
        }

        public void DeleteTask(Task task)
        {
            _tasksInfo.Remove(task);
        }

        #endregion Task Methods
    }
}