namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using DTO;
    using QueueManagement;

    /// <summary>
    ///     Sending Task.
    /// </summary>
    public abstract class SendingTask : ISendingTask
    {
        private readonly IMessageQueue _messageQueue;

        protected SendingTask()
        {
            _messageQueue = new SpuMessageQueue();
        }

        protected SendingTask(IMessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public SendingType Type { get; set; }

        public virtual bool Send(Task newTask)
        {
            if (newTask == null)
            {
                return false;
            }

            _messageQueue.Send(newTask, Type.ToString());

            return true;
        }
    }
}