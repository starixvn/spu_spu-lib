namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using QueueManagement;

    public class ActivatingWorkflow : SendingMessage
    {
        public ActivatingWorkflow()
        {
            Type = SendingType.ActivatingWorkflow;
        }

        protected ActivatingWorkflow(IMessageQueue messageQueue)
            : base(messageQueue)
        {
            Type = SendingType.DeactivatingWorkflow;
        }
    }
}