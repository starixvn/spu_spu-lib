// --------------------------------------------------------------------------
// <copyright file="TaskDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DataAccess.Implement
{
    using Core.Utilities;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;
    
    /// <summary>
    ///     Task Data Access Implement.
    /// </summary>
    public class TaskDataAccess : BaseDataAccess, ITaskDataAccess
    {
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

        public DataCollection GetTasksByCaseId(ICriteria criteria)
        {
            return ReturnDataCollection(criteria);
        }
    }
}