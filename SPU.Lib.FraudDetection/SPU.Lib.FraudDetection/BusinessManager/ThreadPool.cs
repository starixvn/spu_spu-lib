// --------------------------------------------------------------------------
// <copyright file="ThreadPool.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Timers;

    /// <summary>
    /// Workflow Class.
    /// </summary>
    public static class ThreadPool
    {
        private static List<Thread> _threads = new List<Thread>();        
        private static string _threadNameTemplate = "Task {0}";
        
        /// <summary>
        /// Add and start a task in the thread pool.
        /// </summary>
        /// <param name="task">The task to execute.</param>        
        internal static void AddTask(Task task)
        {
            try
            {
                string threadName = string.Format(_threadNameTemplate, task.TaskInfo.TaskName).ToLower();

                if (_threads.Find(x => x.Name.ToLower().Equals(threadName)) == null)
                {
                    ThreadStart action = new ThreadStart(() =>
                    {
                        System.Timers.Timer aTimer = new System.Timers.Timer(task.TaskInfo.Timer);
                        aTimer.Elapsed += new ElapsedEventHandler(task.Scan);                        
                        aTimer.Enabled = true;                        
                    });

                    Thread thread = new Thread(action);
                    thread.Name = threadName;
                    thread.Start();

                    ////Using Join if we want to execute the thread immediately (blocking calling other threads)
                    //if (Thread.CurrentThread.Name != thread.Name && thread.ThreadState != ThreadState.Unstarted)
                    //{
                    //    //// avoid the app hangs due to the current thread waits upon itselft indefinitely
                    //    thread.Join();
                    //}

                    _threads.Add(thread);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Add a task into the thread pool -- " + ex.Message);
            }
        }

        /// <summary>
        /// Remove a task out the thread pool.
        /// </summary>
        /// <param name="taskName">The task name.</param>
        /// <returns>True if item is successfully removed; otherwise, false.</returns>
        internal static void RemoveTask(string taskName)
        {
            try
            {
                string threadName = string.Format(_threadNameTemplate, taskName).ToLower();
                Thread removedThread = _threads.Find(x => x.Name.ToLower().Equals(threadName));
                if (removedThread != null)
                {
                    _threads.Remove(removedThread);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Remove a task out the thread pool -- " + ex.Message);
            }
        }

        internal static void StopAllTasks()
        {
            try
            {                
                foreach (Thread thread in _threads)
                {
                    thread.Abort();
                }
                _threads.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Stop and remove all tasks out the thread pool -- " + ex.Message);
            }
        }     
    }
}
