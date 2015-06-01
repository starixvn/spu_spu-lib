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

        private List<Task> _allTasks = new List<Task>();

        public MessageQueue _OperationMessageQueue = null;

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
                    var qItem = msg.Body as Task;
                    qItem.Scan(this, null);                    
                    //ProcessQueuedWorkItem(qItem);
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
                    var newTask = new Task(taskInfo);
                    
                    _allTasks.Add(newTask);
                    OperationMessageQueue.Send(newTask);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ScanSuspiciousTickets()
        {
            try
            {
                foreach (Task task in _allTasks)
                {
                    if (task.TaskInfo.IsActive)
                    {
                        if (task.TaskInfo.IsBackgroundProcess)
                        {
                            ThreadPool.AddTask(task);
                        }
                        else
                        {                            
                            task.Scan(null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public void Stop()
        {
            try
            {
                ThreadPool.StopAllTasks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Task> Tasks
        {
            get { return _allTasks; }
        }
    }
}
