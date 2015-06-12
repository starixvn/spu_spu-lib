// --------------------------------------------------------------------------
// <copyright file="IWorkflowDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Interface
{
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.Core;    

    /// <summary>
    /// Workflow Data Access interface.
    /// </summary>
    public interface IWorkflowDataAccess
    {
        ICommandResult InsertWorkflow(ICriteria criteria);

        ICommandResult UpdateWorkflow(ICriteria criteria);

        ICommandResult DeleteWorkflow(ICriteria criteria);

        DataCollection GetWorkflows(ICriteria criteria);
    }
}
