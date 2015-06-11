using System;
using System.Messaging;
using System.Security.Cryptography.X509Certificates;
using SPU.Lib.FraudDetection.BusinessManager;
using SPU.Lib.FraudDetection.SendingTasks;

namespace SPU.Lib.FraudDetection
{
    /// <summary>
    /// FraudAutoDetection Class.
    /// </summary>
    public class TaskManager : ITaskManager
    {
        private ITaskManager _threadPool;

        /// <summary>
        /// Loading all tasks for scanning suspicious tickets.
        /// </summary>
        public TaskManager()
        {
            _threadPool = new TaskManager();
        }

        //private void Mq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        //{
        //    using (var msg = _messageQueue.EndReceive(e.AsyncResult))
        //    {
        //        try
        //        {
        //            var task = msg.Body as Task;
        //            if (msg.Label.Equals("UPDATE_TASK"))
        //            {
        //                _threadPool.UpdateTask(task);
        //            }
        //            else if (msg.Label.Equals("REMOVE_TASK"))
        //            {
        //                _threadPool.RemoveTask(task);
        //            }
        //            else
        //            {
        //                _threadPool.AddTask(task);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Fanex.Logging.Logger.Log.Error("Exception Mq_ReceiveCompleted: " + ex.Message);
        //            //TODO : Write to the log we failed in some way
        //            Environment.Exit(Environment.ExitCode);
        //        }
        //    }

        //    _messageQueue.BeginReceive();
        //}

        /// <summary>
        /// The API to add new Task to the queue for scanning.
        /// </summary>
        /// <param name="newTask">The new task.</param>
        /// <returns>True if success.</returns>
        public bool AddNewTask(Task newTask)
        {
            var sender = SendingTaskFactory.GetSender(SendingType.AddingTask);
            return sender.Send(newTask);
        }

        public bool UpdateTask(Task task)
        {
            var sender = SendingTaskFactory.GetSender(SendingType.UpdatingTask);
            return sender.Send(task);
        }

        public bool RemoveTask(Task task)
        {
            var sender = SendingTaskFactory.GetSender(SendingType.RemovingTask);
            return sender.Send(task);
        }

        //public void Stop()
        //{
        //    try
        //    {
        //        _threadPool.StopAllTasks();
        //        _messageQueue.ReceiveCompleted -= Mq_ReceiveCompleted;
        //        _messageQueue.Stop();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}