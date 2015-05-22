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

    /// <summary>
    /// Workflow Class.
    /// </summary>
    public static class ThreadPool
    {
        private static List<Thread> _threads = new List<Thread>();        
        private static string _threadNameTemplate = "Task {0}";

        private static Boolean shouldrun = true;
        
        /// <summary>
        /// Add and start a task in the thread pool.
        /// </summary>
        /// <param name="task">The task to execute.</param>
        /// <param name="threadAction">The action of the task.</param>        
        internal static void AddTask(Task task, Action threadAction)
        {
            try
            {                                
                ThreadStart action = new ThreadStart(() =>
                {
                    while (shouldrun)
                    {
                        threadAction();
                    }
                });

                Thread thread = new Thread(action);
                thread.Name = string.Format(_threadNameTemplate, task.TaskInfo.TaskName);

                thread.Start();

                //if (Thread.CurrentThread.Name != thread.Name && thread.ThreadState != ThreadState.Unstarted)
                //{
                //    //// avoid the app hangs due to the current thread waits upon itselft indefinitely
                //    thread.Join();
                //}

                _threads.Add(thread);                
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
        internal static bool DeleteTask(string taskName)
        {
            try
            {
                Thread removedThread = _threads.Find(x => x.Name == string.Format(_threadNameTemplate, taskName));
                return _threads.Remove(removedThread);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Remove a task out the thread pool -- " + ex.Message);
            }
        }

        internal static void RemoveAllTasks()
        {
            shouldrun = false;
            foreach (Thread thread in _threads)
            {
                thread.Abort();
            }
            _threads.Clear();            
        }
    }
}
