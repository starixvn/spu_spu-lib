namespace SPU.Lib.FraudDetection.SendingTasks
{
    using QueueManagement;

    public class AddingTask : SendingTask
    {
        public AddingTask()
        {
            Type = SendingType.AddingTask;
        }

        public AddingTask(IMessageQueue messageQueue)
            : base(messageQueue)
        {
            Type = SendingType.AddingTask;
        }
    }
}