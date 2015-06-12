using System.Messaging;

namespace SPU.Lib.FraudDetection
{
    public interface IReceivingMessageHandler
    {
        void HandleReceivedMessage(object sender, ReceiveCompletedEventArgs e);

        void TriggerReceivingMessage();
    }
}