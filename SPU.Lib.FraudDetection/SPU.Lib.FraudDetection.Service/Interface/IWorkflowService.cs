// --------------------------------------------------------------------------
// <copyright file="IWorkflowService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Interface
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.Core;
    using SPU.Lib.FraudDetection.DTO;    

    /// <summary>
    /// Workflow Service interface.
    /// </summary>
    public interface IWorkflowService
    {
        ICommandResult InsertWorkflow(ICriteria criteria);

        ICommandResult DeleteWorkflow(ICriteria criteria);

        IEnumerable<WorkflowInfo> LoadWorkflows(ICriteria criteria);

        DataCollection GetWorkflows(ICriteria criteria);

        IEnumerable<TaskInfo> GetTasks(ICriteria criteria);

        ICommandResult UpdateWorkflow(ICriteria criteria);

        void Dispose();
    }
}