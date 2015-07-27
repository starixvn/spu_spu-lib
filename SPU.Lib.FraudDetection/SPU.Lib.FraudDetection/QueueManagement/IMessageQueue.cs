namespace SPU.Lib.FraudDetection.QueueManagement
{
    using System;
    using System.Messaging;

    /// <summary>
    ///     Message Queue interface.
    /// </summary>
    public interface IMessageQueue
    {
        void AttachReceiveCompletedEventHandler(ReceiveCompletedEventHandler receiveCompleted);

        void DeattachReceiveCompletedEventHandler(ReceiveCompletedEventHandler receiveCompleted);

        void Send(object task);

        void Send(object task, string label);

        void Stop();

        void Clear();

        void BeginReceive();

        Message EndReceive(IAsyncResult asyncResult);
    }
}