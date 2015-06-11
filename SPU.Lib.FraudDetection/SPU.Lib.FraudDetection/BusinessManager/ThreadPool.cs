// --------------------------------------------------------------------------
// <copyright file="ThreadPool.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

using System;
using System.Collections.Generic;
using System.Messaging;

namespace SPU.Lib.FraudDetection.BusinessManager
{
    public interface ITaskManager
    {
        List<TaskTimer> ThreadTimerList { get; set; }

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

    /// <summary>
    /// Workflow Class.
    /// </summary>
    public class TaskManager : ITaskManager
    {
        public List<TaskTimer> ThreadTimerList { get; set; }

        public TaskManager()
        {
            ThreadTimerList = new List<TaskTimer>();
        }

        /// <summary>
        /// Add and start a task in the thread pool.
        /// </summary>
        /// <param name="task">The task to execute.</param>
        public void AddTask(Task task)
        {
            try
            {
                if (ThreadTimerList.Find(x => x.TaskId == task.TaskInfo.TaskId) == null)
                {
                    TaskTimer threadTimer = new TaskTimer(task.TaskInfo.Timer);
                    threadTimer.TimerName = task.TaskInfo.TaskName;
                    threadTimer.Elapsed += task.Scan;
                    threadTimer.Enabled = true;

                    ThreadTimerList.Add(threadTimer);
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
        /// <returns>True if item is successfully removed; otherwise, false.</returns>
        public void RemoveTask(Task task)
        {
            try
            {
                var threadTimer = ThreadTimerList.Find(x => x.TimerName.ToLower().Equals(task.TaskInfo.TaskName));
                if (threadTimer != null)
                {
                    threadTimer.Stop();
                    threadTimer.Dispose();
                    ThreadTimerList.Remove(threadTimer);
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
                foreach (TaskTimer threadTimer in ThreadTimerList)
                {
                    threadTimer.Stop();
                    threadTimer.Close();
                    threadTimer.Dispose();
                }

                ThreadTimerList.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Stop and remove all tasks out the thread pool -- " + ex.Message);
            }
        }
    }
}