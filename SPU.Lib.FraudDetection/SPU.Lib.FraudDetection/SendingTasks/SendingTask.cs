// --------------------------------------------------------------------------
// <copyright file="SendingTask.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.SendingTasks
{
    using DTO;
    using QueueManagement;

    /// <summary>
    ///     Sending Task.
    /// </summary>
    public abstract class SendingTask : ISendingTask
    {
        private readonly IMessageQueue _messageQueue;

        protected SendingTask()
        {
            _messageQueue = new SpuMessageQueue();
        }

        protected SendingTask(IMessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public SendingType Type { get; set; }

        public virtual bool Send(Task newTask)
        {
            if (newTask == null)
            {
                return false;
            }

            _messageQueue.Send(newTask, Type.ToString());

            return true;
        }
    }
}