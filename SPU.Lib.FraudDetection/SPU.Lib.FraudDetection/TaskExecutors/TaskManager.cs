namespace SPU.Lib.FraudDetection.TaskExecutors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.Task;
    using DTO;
    using Fanex.Logging;
    using Service.Implement;
    using Service.Interface;

    /// <summary>
    ///     Workflow Class.
    /// </summary>
    public class TaskManager : ITaskManager
    {
        private readonly ITaskService _taskService;

        public TaskManager()
        {
            TaskExecutors = new List<TaskExecutor>();
            _taskService = new TaskService();
        }

        public TaskManager(ITaskService taskService)
        {
            TaskExecutors = new List<TaskExecutor>();
            _taskService = taskService;
        }

        public IList<TaskExecutor> TaskExecutors { get; set; }

        /// <summary>
        ///     Add and start a task in the thread pool.
        /// </summary>
        /// <param name="taskId">The task to execute.</param>
        public void AddTask(int taskId)
        {
            try
            {
                var task =_taskService.GetTaskInfoByTaskId(new TaskInfoSelectCriteria()
                {
                    TaskId = taskId
                });

                AddTask(task);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        public void AddTasksInWorkflow(int workflowId)
        {
            var tasks = _taskService.GetTasksByWorkflowId(new TaskSelectByWorkflowIdCriteria()
            {
                WorkFlowId = workflowId
            });

            foreach (var task in tasks)
            {
                AddTask(task);
            }
        }

        public void ClearTasks()
        {
            foreach (var taskExecutor in TaskExecutors)
            {
                taskExecutor.Stop();
            }

            TaskExecutors.Clear();
        }

        public bool Exist(Task task)
        {
            return TaskExecutors.Any(x => x.TaskId == task.TaskId);
        }

        /// <summary>
        ///     Remove a task out the thread pool.
        /// </summary>
        /// <param name="taskId">The task name.</param>
        /// <returns>True if item is successfully removed; otherwise, false.</returns>
        public void RemoveTask(int taskId)
        {
            try
            {
                var taskExecutor =
                    TaskExecutors.SingleOrDefault(
                        x => x.Task.TaskId == taskId);

                if (taskExecutor == null)
                {
                    return;
                }

                taskExecutor.Stop();
                TaskExecutors.Remove(taskExecutor);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        public void RemoveTasksInWorkflow(int workflowId)
        {
            var taskExecutorsForWorkflow = TaskExecutors.Where(t => t.Task.WorkflowId == workflowId);

            foreach (var taskExecutor in taskExecutorsForWorkflow)
            {
                taskExecutor.Stop();
                TaskExecutors.Remove(taskExecutor);
            }
        }

        /// <summary>
        ///     Update a task.
        /// </summary>
        /// <param name="taskId">The task to update.</param>
        public void UpdateTask(int taskId)
        {
            RemoveTask(taskId);

            AddTask(taskId);
        }

        protected void WriteLog(Exception exception)
        {
            var message = "\r\nError:" + exception.Message +
                          "\r\nStackTrace: " + exception.StackTrace;

            Logger.Log.Error(message);
        }

        private void AddTask(Task task)
        {
            if (!task.IsActive || Exist(task))
            {
                return;
            }

            var taskExecutor = TaskExecutorFactory.GetTaskExecutor(task);

            TaskExecutors.Add(taskExecutor);

            taskExecutor.Start();
        }
    }
}