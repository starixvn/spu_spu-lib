// --------------------------------------------------------------------------
// <copyright file="Task.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
//   <change who="Long.Luu" date="2015.04.01">Modified: TaskInfo</change>
// </history>

namespace SPU.Lib.FraudDetection.TaskExecutors
{
    using System;
    using System.Diagnostics;
    using System.Timers;
    using DTO;
    using Fanex.Logging;
    using Service.Implement;
    using Service.Interface;

    public interface ITaskExecutor
    {
        void Start();
        void Stop();
        void Execute();
    }

    /// <summary>
    ///     Task Class.
    /// </summary>
    public abstract class TaskExecutor : ITaskExecutor
    {
        #region Constructor

        private bool IsRunning { get; set; }

        public Timer Timer { get; set; }
        

        protected TaskExecutor(Task task)
        {
            Task = task;
            TaskService = new TaskService();
            IsRunning = false;
        }

        protected TaskExecutor(Task task, ITaskService taskService)
        {
            Task = task;
            TaskService = taskService;
        }

        #endregion Constructor

        #region Properties

        protected const int ChunkSize = 60;

        public Task Task { get; set; }

        public ITaskService TaskService { get; set; }

        public int TaskId
        {
            get { return Task.TaskId; }
        }

        #endregion Properties

        #region Execute task

        public void Start()
        {
            Timer = new Timer
            {
                Interval = Task.Timer,
                AutoReset = true,
                Enabled = true
            };

            Timer.Elapsed += PreExecute;

            Timer.Start();

            // Execute the task immediately.

            PreExecute(null, null);
        }

        public void Stop()
        {
            Timer.Elapsed -= PreExecute;
            Timer.Stop();
            Timer.Close();
            Timer.Dispose();
        }

        public virtual void PreExecute(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (IsRunning)
            {
                return;
            }

            #if DEBUG
                Console.WriteLine("{0} - {1} - {2} is running", Task.WorkflowId, Task.TaskId, Task.TaskName);
                var stopwatch = new Stopwatch();
                stopwatch.Start();
            #endif

            IsRunning = true;

            Execute();

            IsRunning = false;

            #if DEBUG
                stopwatch.Stop();
                Console.WriteLine("{0} - {1} - {2} spent {3} running", Task.WorkflowId, Task.TaskId, Task.TaskName, stopwatch.Elapsed.ToString());
            #endif
        }

        public abstract void Execute();

        protected abstract void ExecuteRule();

        protected abstract void TakeNextAction();

        protected void WriteLog(Exception exception)
        {
            var message = "\r\nError:" + exception.Message +
                          "\r\nStackTrace: " + exception.StackTrace;

            Logger.Log.Error(message);
        }

        #endregion Scan
    }
}