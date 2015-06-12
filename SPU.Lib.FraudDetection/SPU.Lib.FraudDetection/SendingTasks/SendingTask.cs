using SPU.Lib.FraudDetection.BusinessManager;

namespace SPU.Lib.FraudDetection.SendingTasks
{
    public abstract class SendingTask : ISendingTask
    {
        protected IMessageQueue _messageQueue;

        public SendingType Type { get; set; }

        protected SendingTask()
        {
            _messageQueue = new SpuMessageQueue();
        }

        protected SendingTask(IMessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
        }

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