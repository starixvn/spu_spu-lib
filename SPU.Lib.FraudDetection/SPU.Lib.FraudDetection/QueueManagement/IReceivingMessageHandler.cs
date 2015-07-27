namespace SPU.Lib.FraudDetection.QueueManagement
{
    using System.Messaging;

    /// <summary>
    /// Receiving Message Handler.
    /// </summary>
    public interface IReceivingMessageHandler
    {
        void HandleReceivedMessage(object sender, ReceiveCompletedEventArgs e);

        void TriggerReceivingMessage();

        void ClearTasks();
    }
}