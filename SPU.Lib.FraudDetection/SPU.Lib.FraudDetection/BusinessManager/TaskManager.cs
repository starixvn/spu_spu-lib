using System;
using System.Collections.Generic;
using System.Linq;

namespace SPU.Lib.FraudDetection.BusinessManager
{
    /// <summary>
    /// Workflow Class.
    /// </summary>
    public class TaskManager : ITaskManager
    {
        public List<TaskTimer> TaskTimers { get; set; }

        public TaskManager()
        {
            TaskTimers = new List<TaskTimer>();
        }

        /// <summary>
        /// Add and start a task in the thread pool.
        /// </summary>
        /// <param name="task">The task to execute.</param>
        public void AddTask(Task task)
        {
            if (Exist(task))
            {
                return;
            }

            var threadTimer = new TaskTimer(task.TaskInfo.Timer)
            {
                TaskCode = task.TaskCode,
                TimerName = task.TaskInfo.TaskName
            };

            threadTimer.Elapsed += task.Scan;
            threadTimer.Enabled = true;

            TaskTimers.Add(threadTimer);
        }

        /// <summary>
        /// Update a task.
        /// </summary>
        /// <param name="task">The task to update.</param>
        public void UpdateTask(Task task)
        {
            RemoveTask(task);
            AddTask(task);
        }

        /// <summary>
        /// Remove a task out the thread pool.
        /// </summary>
        /// <param name="task">The task name.</param>
        /// <returns>True if item is successfully removed; otherwise, false.</returns>
        public void RemoveTask(Task task)
        {
            var taskTimer = TaskTimers.SingleOrDefault(x => x.TaskCode.Equals(task.TaskCode, StringComparison.OrdinalIgnoreCase));

            if (taskTimer == null)
            {
                return;
            }

            taskTimer.Stop();
            taskTimer.Dispose();
            TaskTimers.Remove(taskTimer);
        }

        public void ClearTasks()
        {
            foreach (TaskTimer threadTimer in TaskTimers)
            {
                threadTimer.Stop();
                threadTimer.Close();
                threadTimer.Dispose();
            }

            TaskTimers.Clear();
        }

        public bool Exist(Task task)
        {
            return TaskTimers.Any(x => x.TaskCode.Equals(task.TaskCode, StringComparison.OrdinalIgnoreCase));
        }
    }
}