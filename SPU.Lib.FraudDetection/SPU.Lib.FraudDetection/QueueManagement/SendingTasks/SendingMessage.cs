namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    public abstract class SendingMessage : ISendingMessage
    {
        protected IMessageQueue _messageQueue;

        protected SendingMessage()
        {
            _messageQueue = new SpuMessageQueue();
        }

        protected SendingMessage(IMessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public SendingType Type { get; set; }

        public abstract bool Send(object message);

        protected abstract bool IsValidMessage(object message);
    }
}