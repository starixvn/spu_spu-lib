// --------------------------------------------------------------------------
// <copyright file="WorkflowService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using Core;
    using DataAccess.Implement;
    using DataAccess.Interface;
    using DTO;
    using Fanex.NAP.Framework.Command;
    using Fanex.Data.Repository;
    using Interface;

    /// <summary>
    /// Workflow Service.
    /// </summary>
    public class WorkflowService : QueryService, IWorkflowService
    {
        private IWorkflowDataAccess _workflowDataAccess;

        public WorkflowService()
        {
            _workflowDataAccess = new WorkflowDataAccess();
        }

        public ICommandResult InsertWorkflow(ICriteria criteria)
        {
            return _workflowDataAccess.InsertWorkflow(criteria);
        }

        public ICommandResult DeleteWorkflow(ICriteria criteria)
        {
            return _workflowDataAccess.DeleteWorkflow(criteria);
        }

        public IEnumerable<WorkflowInfo> LoadWorkflows(ICriteria criteria)
        {
            return GetData<WorkflowInfo>(criteria);
        }

        public DataCollection GetWorkflows(ICriteria criteria)
        {
            return _workflowDataAccess.GetWorkflows(criteria);
        }

        public IEnumerable<Task> GetTasks(ICriteria criteria)
        {
            return GetData<Task>(criteria);
        }

        public ICommandResult UpdateWorkflow(ICriteria criteria)
        {
            return _workflowDataAccess.UpdateWorkflow(criteria);
        }

        public WorkflowInfo GetWorkflowById(ICriteria criteria)
        {
            return this.Get<WorkflowInfo>(criteria);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}