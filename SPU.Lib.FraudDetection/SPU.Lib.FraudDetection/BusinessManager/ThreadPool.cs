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
    using System.Messaging;
    using System.Threading;
    using System.Timers;

    /// <summary>
    /// Workflow Class.
    /// </summary>
    public static class ThreadPool
    {                
        private static string _threadNameTemplate = "Task {0}";

        private static List<ThreadTimer> _threadTimerList = new List<ThreadTimer>();
        
        /// <summary>
        /// Add and start a task in the thread pool.
        /// </summary>
        /// <param name="task">The task to execute.</param>        
        internal static void AddTask(Task task)
        {
            try
            {
                string timerName = string.Format(_threadNameTemplate, task.TaskInfo.TaskName).ToLower();

                if (_threadTimerList.Find(x => x.TimerName.ToLower().Equals(timerName)) == null)
                {
                    ThreadTimer threadTimer = new ThreadTimer(task.TaskInfo.Timer);
                    threadTimer.TimerName = task.TaskInfo.TaskName;
                    threadTimer.Elapsed += new ElapsedEventHandler(task.Scan);
                    threadTimer.Enabled = true;

                    _threadTimerList.Add(threadTimer);                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Add a task into the thread pool -- " + ex.Message);
            }
        }

        ///// <summary>
        ///// Add and start a task in the thread pool.
        ///// </summary>
        ///// <param name="task">The task to execute.</param>        
        //internal static void AddTask(Task task)
        //{
        //    try
        //    {
        //        string threadName = string.Format(_threadNameTemplate, task.TaskInfo.TaskName).ToLower();

        //        if (_threads.Find(x => x.Name.ToLower().Equals(threadName)) == null)
        //        {
        //            ThreadStart action = new ThreadStart(() =>
        //            {
        //                System.Timers.Timer aTimer = new System.Timers.Timer(task.TaskInfo.Timer);
        //                aTimer.Elapsed += new ElapsedEventHandler(task.Scan);
        //                aTimer.Enabled = true;
        //            });

        //            Thread thread = new Thread(action);
        //            thread.Name = threadName;
        //            thread.Start();

        //            ////Using Join if we want to execute the thread immediately (blocking calling other threads)
        //            //if (Thread.CurrentThread.Name != thread.Name && thread.ThreadState != ThreadState.Unstarted)
        //            //{
        //            //    //// avoid the app hangs due to the current thread waits upon itselft indefinitely
        //            //    thread.Join();
        //            //}

        //            _threads.Add(thread);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Exception Add a task into the thread pool -- " + ex.Message);
        //    }
        //}

        /// <summary>
        /// Update a task.
        /// </summary>
        /// <param name="task">The task to update.</param>
        internal static void UpdateTask(Task task)
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
        /// <param name="taskName">The task name.</param>
        /// <returns>True if item is successfully removed; otherwise, false.</returns>
        internal static void RemoveTask(Task task)
        {
            try
            {
                var threadTimer = _threadTimerList.Find(x => x.TimerName.ToLower().Equals(task.TaskInfo.TaskName));
                if (threadTimer != null)
                {
                    threadTimer.Stop();
                    threadTimer.Dispose();
                    _threadTimerList.Remove(threadTimer);
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
                foreach (ThreadTimer threadTimer in _threadTimerList)
                {
                    threadTimer.Stop();
                    threadTimer.Dispose();
                    _threadTimerList.Remove(threadTimer);
                }                
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Stop and remove all tasks out the thread pool -- " + ex.Message);
            }
        }

        internal static void AsynchronousTask()
        {
            MessageQueue myQueue = new MessageQueue(".\\myQueue");
            myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });

            // Add an event handler for the ReceiveCompleted event.
            myQueue.ReceiveCompleted += new
                ReceiveCompletedEventHandler(MyReceiveCompleted);

            // Begin the asynchronous receive operation.
            myQueue.BeginReceive();

            // Do other work on the current thread.

            return;
        }

        internal static void MyReceiveCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            // Connect to the queue.
			MessageQueue mq = (MessageQueue)source;

			// End the asynchronous Receive operation.
			Message m = mq.EndReceive(asyncResult.AsyncResult);

			// Display message information on the screen.
			Console.WriteLine("Message: " + (string)m.Body);

			// Restart the asynchronous Receive operation.
			mq.BeginReceive();
			            
			return; 
        }
    }
}
