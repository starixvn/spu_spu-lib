namespace SPU.Lib.FraudDetection.QueueManagement.SendingWorklows
{
    using QueueManagement;
    using SendingTasks;

    public class DeactivatingCase : SendingMessage
    {
        public DeactivatingCase()
        {
            Type = SendingType.DeactivatingCase;
        }

        protected DeactivatingCase(IMessageQueue messageQueue)
            : base(messageQueue)
        {
            Type = SendingType.DeactivatingCase;
        }
    }
}