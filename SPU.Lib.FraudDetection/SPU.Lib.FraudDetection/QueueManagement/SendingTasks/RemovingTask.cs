namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using QueueManagement;
    using Service.Interface;

    /// <summary>
    ///     Removing Task.
    /// </summary>
    public class RemovingTask : SendingMessage
    {
        public RemovingTask()
        {
            Type = SendingType.RemovingTask;
        }

        public RemovingTask(IMessageQueue messageQueue)
            : base(messageQueue)
        {
            Type = SendingType.RemovingTask;
        }
    }
}