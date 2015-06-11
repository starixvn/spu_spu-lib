namespace SPU.Lib.FraudDetection.SendingTasks
{
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