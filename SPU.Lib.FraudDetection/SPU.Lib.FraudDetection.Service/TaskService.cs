// --------------------------------------------------------------------------
// <copyright file="TaskService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DataAccess;
    using SPU.Lib.FraudDetection.DTO;

    /// <summary>
    /// Task Service.
    /// </summary>
    public class TaskService : QueryService
    {
        private TaskDataAccess _taskDataAccess;

        public TaskService()
        {
            _taskDataAccess = new TaskDataAccess();
        }

        public ICommandResult InsertTask(ICriteria criteria)
        {
            return _taskDataAccess.InsertTask(criteria);
        }

        public ICommandResult DeleteTask(ICriteria criteria)
        {
            return _taskDataAccess.DeleteTask(criteria);
        }

        public IEnumerable<TaskInfo> GetTasksByWorkflow(ICriteria criteria)
        {
            return GetData<TaskInfo>(criteria);
        }

        public ICommandResult UpdateTask(ICriteria criteria)
        {
            return _taskDataAccess.UpdateTask(criteria);
        }
    }
}
