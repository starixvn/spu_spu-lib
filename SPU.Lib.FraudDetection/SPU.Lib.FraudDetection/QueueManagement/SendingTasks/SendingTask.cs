namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using DTO;
    using QueueManagement;

    /// <summary>
    ///     Sending Task.
    /// </summary>
    public abstract class SendingTask : SendingMessage
    {
        protected SendingTask()
            : base()
        {
        }

        protected SendingTask(IMessageQueue messageQueue)
            : base(messageQueue)
        {
        }

        public override bool Send(object message)
        {
            if (!IsValidMessage(message))
            {
                return false;
            }

            _messageQueue.Send(message, Type.ToString());

            return true;
        }

        protected override bool IsValidMessage(object message)
        {
            var isTask = message is Task;

            if (message == null || !isTask)
            {
                return false;
            }

            return true;
        }
    }
}