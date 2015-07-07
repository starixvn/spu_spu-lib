namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using QueueManagement;

    public class ActivatingCase : SendingMessage
    {
        public ActivatingCase()
        {
            Type = SendingType.ActivatingCase;
        }

        protected ActivatingCase(IMessageQueue messageQueue)
            : base(messageQueue)
        {
            Type = SendingType.DeactivatingCase;
        }
    }
}