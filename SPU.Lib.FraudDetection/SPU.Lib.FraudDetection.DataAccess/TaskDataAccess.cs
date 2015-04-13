// --------------------------------------------------------------------------
// <copyright file="TaskDataAccess.cs" company="Nexcel Solutions Vietnam">
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
    /// Task Data Access.
    /// </summary>
    public class TaskDataAccess : BaseDataAccess
    {
        public TaskDataAccess() : base()
        {
        }

        public ICommandResult InsertTask(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult UpdateTask(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult DeleteTask(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}
