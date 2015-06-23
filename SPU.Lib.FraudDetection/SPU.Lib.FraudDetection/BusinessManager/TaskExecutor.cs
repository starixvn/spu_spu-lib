// --------------------------------------------------------------------------
// <copyright file="Task.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
//   <change who="Long.Luu" date="2015.04.01">Modified: TaskInfo</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager
{
    using System;
    using System.Timers;
    using DTO;
    using Service.Implement;
    using Service.Interface;

    /// <summary>
    /// Task Class.
    /// </summary>
    public abstract class TaskExecutor
    {
        #region Constructor

        public Timer Timer { get; set; }

        protected TaskExecutor(Task task)
        {
            Task = task;

            Timer = new Timer
            {
                Interval = task.Timer,
                AutoReset = true,
                Enabled = true
            };

            TaskService = new TaskService();
        }

        protected TaskExecutor(Task task, ITaskService taskService)
        {
            Task = task;

            Timer = new Timer
            {
                Interval = task.Timer,
                AutoReset = true,
                Enabled = true
            };

            TaskService = taskService;
        }

        #endregion Constructor

        #region Properties

        public Task Task { get; set; }

        public ITaskService TaskService { get; set; }

        public string TaskCode
        {
            get { return Task.TaskCode; }
        }

        #endregion Properties

        #region Execute task

        public void Start()
        {
            Timer.Elapsed += Execute;
            Timer.Start();
        }

        public void Stop()
        {
            Timer.Stop();
            Timer.Close();
            Timer.Dispose();
        }

        public virtual void Execute(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            try
            {
                if (Task.IsActive)
                {
                    ExecutePrecondition();
                    
                    ExecuteRule();

                    TakeNextAction();
                }
            }
            catch (Exception ex)
            {
                Fanex.Logging.Logger.Log.Error("Scan : " + ex.Message);
            }
        }

        protected abstract void ExecutePrecondition();

        protected abstract void ExecuteRule();

        protected abstract void TakeNextAction();

        protected void WriteLog(Exception exception)
        {
            var message = "\r\nError:" + exception.Message +
                          "\r\nStackTrace: " + exception.StackTrace;

            Fanex.Logging.Logger.Log.Error(message);
        }

        #endregion Scan
    }
}