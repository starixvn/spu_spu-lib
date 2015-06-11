// --------------------------------------------------------------------------
// <copyright file="FraudAutoDetection.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.05.21">Created</change>
// </history>

using System;
using System.Messaging;
using SPU.Lib.Core;
using SPU.Lib.FraudDetection.BusinessManager;
using SPU.Lib.FraudDetection.Criteria.Taks;
using SPU.Lib.FraudDetection.DTO;

namespace SPU.Lib.FraudDetection
{
    public class SpuMessageQueue : IMessageQueue
    {
        private MessageQueue _messageQueue;

        public event ReceiveCompletedEventHandler ReceiveCompleted;

        public SpuMessageQueue()
        {
            _messageQueue = new MessageQueue();
            _messageQueue.Path = ConfigSettings.GetConfigStringByName("queuePath");
            _messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(Task) });
            //_messageQueueQueue.ReceiveCompleted += ReceiveCompleted;

            _messageQueue.Purge();
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