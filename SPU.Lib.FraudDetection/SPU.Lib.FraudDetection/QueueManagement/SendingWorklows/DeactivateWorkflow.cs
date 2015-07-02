namespace SPU.Lib.FraudDetection.QueueManagement.SendingWorklows
{
    using QueueManagement;
    using SendingTasks;

    public class DeactivatingWorkflow : SendingMessage
    {
        public DeactivatingWorkflow()
        {
            Type = SendingType.DeactivatingWorkflow;
        }

        protected DeactivatingWorkflow(IMessageQueue messageQueue)
            : base(messageQueue)
        {
            Type = SendingType.DeactivatingWorkflow;
        }
    }
}