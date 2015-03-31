// --------------------------------------------------------------------------
// <copyright file="WorkflowDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess
{
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Workflow Data Access.
    /// </summary>
    public class WorkflowDataAccess : BaseDataAccess
    {
        public WorkflowDataAccess() : base()
        {
        }

        public ICommandResult InsertWorkflow(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);            
        }

        public ICommandResult DeleteWorkflow(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);            
        }

        public ICommandResult UpdateWorkflow(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}
