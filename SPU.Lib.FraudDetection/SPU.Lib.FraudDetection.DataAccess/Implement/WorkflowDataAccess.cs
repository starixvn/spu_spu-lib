// --------------------------------------------------------------------------
// <copyright file="WorkflowDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Implement
{
    using Core;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     Workflow Data Access Implement.
    /// </summary>
    public class WorkflowDataAccess : BaseDataAccess, IWorkflowDataAccess
    {
        public ICommandResult InsertWorkflow(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult UpdateWorkflow(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult DeleteWorkflow(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public DataCollection GetWorkflows(ICriteria criteria)
        {
            return ReturnDataCollection(criteria);
        }
    }
}