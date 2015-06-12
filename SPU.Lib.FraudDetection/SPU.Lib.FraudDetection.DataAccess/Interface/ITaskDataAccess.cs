// --------------------------------------------------------------------------
// <copyright file="ITaskDataAccess.cs" company="Nexcel Solutions Vietnam">
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
    /// Task Data Access interface.
    /// </summary>
    public interface ITaskDataAccess
    {
        ICommandResult InsertTask(ICriteria criteria);

        ICommandResult UpdateTask(ICriteria criteria);

        ICommandResult DeleteTask(ICriteria criteria);

        DataCollection GetTasksByWorkflowId(ICriteria criteria);
    }
}