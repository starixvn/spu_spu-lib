// --------------------------------------------------------------------------
// <copyright file="ReceivingMessageHandler.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace SPU.Lib.FraudDetection
{
    using System;
    using System.Messaging;
    using BusinessManager;
    using SendingTasks;

    /// <summary>
    /// Receiving Message Handler.
    /// </summary>
    public class ReceivingMessageHandler : IReceivingMessageHandler
    {
        private readonly IMessageQueue _queue;
        private readonly ITaskManager _taskManager;

        public long ReceiveMessageCount { get; set; }

        public ReceivingMessageHandler()
        {
            _taskManager = new TaskManager();
            _queue = new SpuMessageQueue();
            _queue.ReceiveCompleted += HandleReceivedMessage;
        }

        public ReceivingMessageHandler(ITaskManager taskManager, IMessageQueue queue)
        {
            _taskManager = taskManager;
            _queue = queue;
            _queue.ReceiveCompleted += HandleReceivedMessage;
        }

        public void HandleReceivedMessage(object sender, ReceiveCompletedEventArgs e)
        {
            ReceiveMessageCount++;

            using (var msg = _queue.EndReceive(e.AsyncResult))
            {
                var task = msg.Body as Task;

                if (string.IsNullOrEmpty(msg.Label))
                {
                    return;
                }

                var type = ConvertLabelIntoSendingType(msg);

                switch (type)
                {
                    case SendingType.AddingTask:
                        _taskManager.AddTask(task);
                        break;

                    case SendingType.UpdatingTask:
                        _taskManager.UpdateTask(task);
                        break;

                    case SendingType.RemovingTask:
                        _taskManager.RemoveTask(task);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            _queue.BeginReceive();
        }

        public void TriggerReceivingMessage()
        {
            _queue.BeginReceive();
        }

        public void ClearTasks()
        {
            _taskManager.ClearTasks();
        }

        private SendingType ConvertLabelIntoSendingType(Message msg)
        {
            SendingType type;
            var result = Enum.TryParse(msg.Label, true, out type);

            return result ? type : SendingType.None;
        }
    }
}