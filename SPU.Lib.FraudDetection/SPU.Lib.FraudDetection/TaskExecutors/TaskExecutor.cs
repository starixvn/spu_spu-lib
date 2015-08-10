// --------------------------------------------------------------------------
// <copyright file="TaskExecutor.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
//   <change who="Long.Luu" date="2015.04.01">Modified: TaskInfo</change>
// </history>

namespace FD.Lib.TaskExecutors
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Timers;
    using DTO;
    using Fanex.Logging;
    using Service.Implement;
    using Service.Interface;
    using Task = DTO.Task;

    /// <summary>
    ///     Task Class.
    /// </summary>
    public abstract class TaskExecutor : ITaskExecutor
    {
        protected const int ChunkSize = 60;

        #region Constructor

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

        public Task Task { get; set; }

        public ITaskService TaskService { get; set; }

        public Timer Timer { get; set; }

        public int TaskId
        {
            get { return Task.TaskId; }
        }

        private bool IsRunning { get; set; }

        private bool IsStop { get; set; }
        
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

        public virtual void Stop()
        {
            IsStop = true;
            Timer.Elapsed -= PreExecute;
            Timer.Stop();
            Timer.Close();
            Timer.Dispose();
        }

        public virtual void PreExecute(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (IsRunning || IsStop)
            {
                return;
            }

            #if DEBUG
                Console.WriteLine("{0} - {1} - {2} is running", Task.CaseId, Task.TaskId, Task.TaskName);
                var stopwatch = new Stopwatch();
                stopwatch.Start();
            #endif

            IsRunning = true;

            Execute();

            IsRunning = false;

            #if DEBUG
                stopwatch.Stop();
                Console.WriteLine("{0} - {1} - {2} spent {3} running", Task.CaseId, Task.TaskId, Task.TaskName, stopwatch.Elapsed.ToString());
            #endif
        }

        public virtual void Execute()
        {
            try
            {
                ClearOldResult();

                ExecutePrecondition();

                ExecuteRule();

                TakeNextAction();
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        protected abstract void ClearOldResult();

        protected abstract void ExecutePrecondition();

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