using SPU.Lib.FraudDetection.BusinessManager;

namespace SPU.Lib.FraudDetection.SendingTasks
{
    public class RemovingTask : SendingTask
    {
        public RemovingTask()
        {
            Type = SendingType.RemovingTask;
        }

        public RemovingTask(IMessageQueue messageQueue)
            : base(messageQueue)
        {
            Type = SendingType.RemovingTask;
        }
    }
}