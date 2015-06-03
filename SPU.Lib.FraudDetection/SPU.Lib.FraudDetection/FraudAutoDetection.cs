// --------------------------------------------------------------------------
// <copyright file="FraudAutoDetection.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.05.21">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager
{
    using System;
    using System.Collections.Generic;
    using SPU.Lib.FraudDetection.Criteria.Taks;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.Service;
using System.Messaging;

    /// <summary>
    /// FraudAutoDetection Class.
    /// </summary>
    public class FraudAutoDetection
    {
        private TaskService _taskService = new TaskService();

        private MessageQueue _OperationMessageQueue = null;

        protected MessageQueue OperationMessageQueue
        {
            get
            {
                if (_OperationMessageQueue == null)
                {
                    _OperationMessageQueue = new MessageQueue();
                    _OperationMessageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(Task) });
                    _OperationMessageQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(Mq_ReceiveCompleted);
                }
                return _OperationMessageQueue;
            }
        }

        /// <summary>
        /// Loading all tasks for scanning suspicious tickets.
        /// </summary>
        public FraudAutoDetection(string queuePath)
        {
            try
            {                
                OperationMessageQueue.Path = queuePath;
                OperationMessageQueue.BeginReceive();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Mq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            using (var msg = OperationMessageQueue.EndReceive(e.AsyncResult))
            {
                try
                {
                    var task = msg.Body as Task;
                    if (msg.Label.Equals("UPDATE_TASK"))
                    {
                        ThreadPool.UpdateTask(task);
                    }
                    else if (msg.Label.Equals("REMOVE_TASK"))
                    {
                        ThreadPool.RemoveTask(task);
                    }
                    else
                    {
                        ThreadPool.AddTask(task);
                    }
                }
                catch (Exception ex)
                {
                    Fanex.Logging.Logger.Log.Error("Exception Mq_ReceiveCompleted: " + ex.Message);
                    //TODO : Write to the log we failed in some way
                    Environment.Exit(Environment.ExitCode);
                }
            }

            OperationMessageQueue.BeginReceive();
        }

        public void LoadTasks()
        {
            try
            {                
                var taskInfoList = _taskService.LoadAllTasks(new TaskSelectAllCriteria());
                foreach (TaskInfo taskInfo in taskInfoList)
                {
                    if (taskInfo.IsActive)
                    {
                        OperationMessageQueue.Send(new Task(taskInfo));                          
                    }
                }                               
            }
            catch (Exception ex)
            {
                Fanex.Logging.Logger.Log.Error("Exception LoadTasks: " + ex.Message);             
            }
        }

        /// <summary>
        /// The API to add new Task to the queue for scanning.
        /// </summary>
        /// <param name="newTask">The new task.</param>
        /// <returns>True if success.</returns>
        public bool AddNewTask(Task newTask)
        {
            bool result = false;
            try
            {
                if (newTask != null && newTask is Task)
                {
                    OperationMessageQueue.Send(newTask);
                    result = true;
                }                
            }
            catch (Exception ex)
            {                
                Fanex.Logging.Logger.Log.Error("Exception AddNewTask: " + ex.Message);
            }

            return result;
        }

        public bool UpdateTask(Task task)
        {
            bool result = false;
            try
            {
                if (task != null && task is Task)
                {
                    OperationMessageQueue.Send(task, "UPDATE_TASK");
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Fanex.Logging.Logger.Log.Error("Exception UpdateTask: " + ex.Message);
            }

            return result;
        }

        public bool RemoveTask(Task task)
        {
            bool result = false;
            try
            {
                if (task != null && task is Task)
                {
                    OperationMessageQueue.Send(task, "REMOVE_TASK");                    
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Fanex.Logging.Logger.Log.Error("Exception RemoveTask: " + ex.Message);
            }

            return result;
        }

        public void Stop()
        {
            try
            {
                ThreadPool.StopAllTasks();

                OperationMessageQueue.ReceiveCompleted -= this.Mq_ReceiveCompleted;                
                OperationMessageQueue.Purge();
                OperationMessageQueue.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
