// --------------------------------------------------------------------------
// <copyright file="FDMessageQueue.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.QueueManagement
{
    using System;
    using System.Messaging;
    using Core.Utilities;
    using Fanex.Logging;

    /// <summary>
    ///     SPU Message Queue.
    /// </summary>
    public class FDMessageQueue : IMessageQueue
    {
        private readonly MessageQueue _messageQueue;

        public FDMessageQueue()
        {
            var queuePath = ConfigSettings.GetConfigStringByName("queuePath");

            try
            {
                _messageQueue = new MessageQueue(queuePath) { Formatter = new XmlMessageFormatter(new[] { typeof(int) }) };
            }
            catch (InvalidOperationException ex)
            {
                Logger.Log.Error("_messageQueue = MessageQueue.Exists(queuePath) .. : " + ex);
            }
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