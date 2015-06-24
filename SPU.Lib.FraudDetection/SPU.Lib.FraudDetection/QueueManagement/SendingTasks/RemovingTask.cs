namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using QueueManagement;

    /// <summary>
    ///     Removing Task.
    /// </summary>
    public class RemovingTask : SendingTask
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