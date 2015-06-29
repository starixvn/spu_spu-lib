namespace SPU.Lib.FraudDetection.QueueManagement
{
    using System;
    using System.Messaging;
    using Core;
    using Fanex.Logging;
    using SPU.Lib.FraudDetection.DTO;
    using TaskExecutors;

    /// <summary>
    ///     SPU Message Queue.
    /// </summary>
    public class SpuMessageQueue : IMessageQueue
    {
        private readonly MessageQueue _messageQueue;

        public SpuMessageQueue()
        {
            var queuePath = ConfigSettings.GetConfigStringByName("queuePath");

            try
            {
                _messageQueue = new MessageQueue(queuePath) { Formatter = new XmlMessageFormatter(new[] { typeof(Task) }) };
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