using System;
using Fanex.Logging;
using SPU.Lib.FraudDetection.BusinessManager;
using SPU.Lib.FraudDetection.Criteria.Task;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.SendingTasks;
using SPU.Lib.FraudDetection.Service.Implement;
using SPU.Lib.FraudDetection.Service.Interface;

namespace SPU.Lib.FraudDetection
{
    public class TaskLoader : ITaskLoader
    {
        private readonly ITaskService _taskService;

        private ISendingTask _sendingTask;

        public TaskLoader()
        {
            _taskService = new TaskService();
            _sendingTask = new AddingTask(new SpuMessageQueue());
        }

        public TaskLoader(ITaskService taskService, IMessageQueue messageQueue)
        {
            _taskService = taskService;
            _sendingTask = new AddingTask(messageQueue);
        }

        public void LoadTasks()
        {
            try
            {
                var taskList = _taskService.LoadAllTasks(new TaskSelectAllCriteria());

                foreach (var task in taskList)
                {
                    if (task.IsActive)
                    {
                        _sendingTask.Send(task);
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