using System;
using Fanex.Logging;
using SPU.Lib.FraudDetection.BusinessManager;
using SPU.Lib.FraudDetection.Criteria.Task;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.Service;

namespace SPU.Lib.FraudDetection
{
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

                foreach (TaskInfo taskInfo in taskInfoList)
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