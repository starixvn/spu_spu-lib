namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using QueueManagement;

    public class DeactivatingWorkflow : SendingTask
    {
        public DeactivatingWorkflow()
        {
            Type = SendingType.DeactivateWorkflow;
        }

        public DeactivatingWorkflow(IMessageQueue messageQueue)
            : base(messageQueue)
        {
            Type = SendingType.DeactivateWorkflow;
        }
    }
}