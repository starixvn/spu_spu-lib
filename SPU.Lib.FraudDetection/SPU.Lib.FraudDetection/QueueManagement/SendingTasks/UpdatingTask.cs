namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using QueueManagement;

    public class UpdatingTask : SendingTask
    {
        public UpdatingTask()
        {
            Type = SendingType.UpdatingTask;
        }

        public UpdatingTask(IMessageQueue messageQueue)
            : base(messageQueue)
        {
            Type = SendingType.UpdatingTask;
        }
    }
}