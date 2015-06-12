// --------------------------------------------------------------------------
// <copyright file="FraudAutoDetection.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace SPU.Lib.FraudDetection
{
    using SPU.Lib.FraudDetection.BusinessManager;
    using SPU.Lib.FraudDetection.SendingTasks;

    /// <summary>
    /// FraudAutoDetection Class.
    /// </summary>
    public class FraudAutoDetection
    {
        private ITaskManager _taskManager;

        public FraudAutoDetection()
        {
            _taskManager = new TaskManager();
        }

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
    }
}