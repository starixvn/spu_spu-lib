namespace SPU.Lib.FraudDetection.TaskLoaders
{
    using System;
    using Criteria.Task;
    using Fanex.Logging;
    using QueueManagement;
    using QueueManagement.SendingTasks;
    using Service.Implement;
    using Service.Interface;

    public class TaskLoader : ITaskLoader
    {
        private readonly ISendingTask _sendingTask;
        private readonly ITaskService _taskService;

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
            var taskList = _taskService.LoadAllTasks(new TaskSelectAllCriteria());

            foreach (var task in taskList)
            {
                if (task.IsActive)
                {
                    _sendingTask.Send(task);
                }
            }
        }
    }
}