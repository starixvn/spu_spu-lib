namespace SPU.Lib.FraudDetection.SendingTasks
{
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