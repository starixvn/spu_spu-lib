namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using QueueManagement;
    using Service.Interface;

    public class AddingTask : SendingMessage
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