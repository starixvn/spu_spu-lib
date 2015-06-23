// --------------------------------------------------------------------------
// <copyright file="SpuMessageQueue.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.05.21">Created</change>
// </history>

namespace SPU.Lib.FraudDetection
{
    using System;
    using System.Messaging;
    using BusinessManager;
    using Core;

    /// <summary>
    /// SPU Message Queue.
    /// </summary>
    public class SpuMessageQueue : IMessageQueue
    {
        private readonly MessageQueue _messageQueue;

        public SpuMessageQueue()
        {
            var queuePath = ConfigSettings.GetConfigStringByName("queuePath");
            _messageQueue = MessageQueue.Exists(queuePath) ? new MessageQueue(queuePath) : MessageQueue.Create(queuePath);
            _messageQueue.Formatter = new XmlMessageFormatter(new[] { typeof(TaskExecutor) });
        }

        public void AttachReceiveCompletedEventHandler(ReceiveCompletedEventHandler receiveCompleted)
        {
            _messageQueue.ReceiveCompleted += receiveCompleted;
        }

        public void DeattachReceiveCompletedEventHandler(ReceiveCompletedEventHandler receiveCompleted)
        {
            _messageQueue.ReceiveCompleted -= receiveCompleted;
        }

        public void Send(object task)
        {
            _messageQueue.Send(task);
        }

        public void Send(object task, string label)
        {
            _messageQueue.Send(task, label);
        }

        public void Stop()
        {
            _messageQueue.Purge();
            _messageQueue.Close();
        }

        public void Clear()
        {
            _messageQueue.Purge();
        }

        public void BeginReceive()
        {
            _messageQueue.BeginReceive();
        }

        public Message EndReceive(IAsyncResult asyncResult)
        {
            return _messageQueue.EndReceive(asyncResult);
        }
    }
}