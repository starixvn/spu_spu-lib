using System.Collections.Generic;

namespace SPU.Lib.FraudDetection.BusinessManager
{
    public interface ITaskManager
    {
        List<TaskTimer> TaskTimerList { get; set; }

        /// <summary>
        /// Add and start a task in the thread pool.
        /// </summary>
        /// <param name="task">The task to execute.</param>
        void AddTask(Task task);

        /// <summary>
        /// Update a task.
        /// </summary>
        /// <param name="task">The task to update.</param>
        void UpdateTask(Task task);

        /// <summary>
        /// Remove a task out the thread pool.
        /// </summary>
        /// <param name="task">The task name.</param>
        /// <returns>True if item is successfully removed; otherwise, false.</returns>
        void RemoveTask(Task task);

        void StopTasks();
    }
}