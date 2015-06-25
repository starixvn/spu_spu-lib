namespace SPU.Lib.FraudDetection.TaskExecutors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DTO;

    /// <summary>
    ///     Workflow Class.
    /// </summary>
    public class TaskManager : ITaskManager
    {
        public TaskManager()
        {
            TaskExecutors = new List<TaskExecutor>();
        }

        public IList<TaskExecutor> TaskExecutors { get; set; }

        /// <summary>
        ///     Add and start a task in the thread pool.
        /// </summary>
        /// <param name="task">The task to execute.</param>
        public void AddTask(Task task)
        {
            if (Exist(task))
            {
                return;
            }

            var taskExecutor = TaskExecutorFactory.GetTaskExecutor(task);

            TaskExecutors.Add(taskExecutor);

            taskExecutor.Start();
        }

        /// <summary>
        ///     Update a task.
        /// </summary>
        /// <param name="task">The task to update.</param>
        public void UpdateTask(Task task)
        {
            RemoveTask(task);
            AddTask(task);
        }

        /// <summary>
        ///     Remove a task out the thread pool.
        /// </summary>
        /// <param name="task">The task name.</param>
        /// <returns>True if item is successfully removed; otherwise, false.</returns>
        public void RemoveTask(Task task)
        {
            var taskExecutor =
                TaskExecutors.SingleOrDefault(x => x.TaskCode.Equals(task.TaskCode, StringComparison.OrdinalIgnoreCase));

            if (taskExecutor == null)
            {
                return;
            }

            taskExecutor.Stop();
            TaskExecutors.Remove(taskExecutor);
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
            return TaskExecutors.Any(x => x.TaskCode.Equals(task.TaskCode, StringComparison.OrdinalIgnoreCase));
        }
    }
}