// --------------------------------------------------------------------------
// <copyright file="ITaskLoader.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace SPU.Lib.FraudDetection
{
    using System;
    using BusinessManager;
    using Criteria.Task;
    using Fanex.Logging;
    using Service.Implement;
    using Service.Interface;

    public interface ITaskLoader
    {
        void LoadTasks();
    }

    public class TaskLoader : ITaskLoader
    {
        private readonly ITaskService _taskService;

        private readonly IMessageQueue _messageQueue;

        public TaskLoader()
        {
            _taskService = new TaskService();
            _messageQueue = new SpuMessageQueue();
        }

        public TaskLoader(ITaskService taskService, IMessageQueue messageQueue)
        {
            _taskService = taskService;
            _messageQueue = messageQueue;
        }

        public void LoadTasks()
        {
            try
            {
                var taskInfoList = _taskService.LoadAllTasks(new TaskSelectAllCriteria());

                foreach (var taskInfo in taskInfoList)
                {
                    if (taskInfo.IsActive)
                    {
                        _messageQueue.Send(new Task(taskInfo));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Exception LoadTasks: " + ex.Message);
            }
        }
    }
}