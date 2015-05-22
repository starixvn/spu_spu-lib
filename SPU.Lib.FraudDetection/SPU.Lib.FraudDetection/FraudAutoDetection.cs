// --------------------------------------------------------------------------
// <copyright file="FraudAutoDetection.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.05.21">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager
{
    using System.Collections.Generic;
    using SPU.Lib.FraudDetection.Criteria.Taks;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.Service;
    using System;

    /// <summary>
    /// FraudAutoDetection Class.
    /// </summary>
    public class FraudAutoDetection
    {
        private TaskService _taskService = new TaskService();

        private List<Task> _allTasks = new List<Task>();

        /// <summary>
        /// Loading all tasks for scanning suspicious tickets.
        /// </summary>
        public FraudAutoDetection()
        {
            var taskInfoList = _taskService.LoadAllTasks(new TaskSelectAllCriteria());
            foreach (TaskInfo taskinfo in taskInfoList)
            {
                _allTasks.Add(new Task(taskinfo));
            }
        }

        public void ScanSuspiciousTickets()
        {
            foreach (Task task in _allTasks)
            {
                if (task.TaskInfo.IsBackgroundProcess)
                {
                    AssignTaskToThreadPool(task);                    
                }
                else
                {
                    task.Scan();
                }
            }
        }

        public void AssignTaskToThreadPool(Task task)
        {
            try
            {
                ThreadPool.AddTask(task, () => { task.Scan(); });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Stop()
        {
            ThreadPool.RemoveAllTasks();
        }

        public List<Task> Tasks
        {
            get { return _allTasks; }
        }
    }
}
