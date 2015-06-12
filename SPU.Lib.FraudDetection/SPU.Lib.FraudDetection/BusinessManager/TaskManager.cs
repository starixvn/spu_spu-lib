// --------------------------------------------------------------------------
// <copyright file="TaskManager.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Workflow Class.
    /// </summary>
    public class TaskManager : ITaskManager
    {        
        public TaskManager()
        {
            TaskTimerList = new List<TaskTimer>();
        }

        public List<TaskTimer> TaskTimerList { get; set; }

        /// <summary>
        /// Add and start a task in the thread pool.
        /// </summary>
        /// <param name="task">The task to execute.</param>
        public void AddTask(Task task)
        {
            try
            {
                if (TaskTimerList.Find(x => x.TaskId == task.TaskInfo.TaskId) == null)
                {
                    var threadTimer = new TaskTimer(task.TaskInfo.Timer);
                    threadTimer.TimerName = task.TaskInfo.TaskName;
                    threadTimer.Elapsed += task.Scan;
                    threadTimer.Enabled = true;

                    TaskTimerList.Add(threadTimer);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Add a task into the thread pool -- " + ex.Message);
            }
        }

        /// <summary>
        /// Update a task.
        /// </summary>
        /// <param name="task">The task to update.</param>
        public void UpdateTask(Task task)
        {
            try
            {
                RemoveTask(task);
                AddTask(task);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Update a task into the thread pool -- " + ex.Message);
            }
        }

        /// <summary>
        /// Remove a task out the thread pool.
        /// </summary>
        /// <param name="task">The task name.</param>
        public void RemoveTask(Task task)
        {
            try
            {
                var threadTimer = TaskTimerList.Find(x => x.TimerName.ToLower().Equals(task.TaskInfo.TaskName));
                if (threadTimer != null)
                {
                    threadTimer.Stop();
                    threadTimer.Dispose();
                    TaskTimerList.Remove(threadTimer);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Remove a task out the thread pool -- " + ex.Message);
            }
        }

        public void StopTasks()
        {
            try
            {
                foreach (TaskTimer threadTimer in TaskTimerList)
                {
                    threadTimer.Stop();
                    threadTimer.Close();
                    threadTimer.Dispose();
                }

                TaskTimerList.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Stop and remove all tasks out the thread pool -- " + ex.Message);
            }
        }
    }
}