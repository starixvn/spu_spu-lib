using System;
using System.Messaging;

namespace SPU.Lib.FraudDetection
{
    public interface IMessageQueue
    {
        void Send(object task);

        void Send(object task, string label);

        event ReceiveCompletedEventHandler ReceiveCompleted;

        void Stop();

        void BeginReceive();

        Message EndReceive(IAsyncResult asyncResult);
    }
}