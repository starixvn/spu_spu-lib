using System;

namespace SPU.Lib.FraudDetection.SendingTasks
{
    public class SendingTaskFactory
    {
        public static ISendingTask GetSender(SendingType type)
        {
            switch (type)
            {
                case SendingType.AddingTask:
                    return new AddingTask();

                case SendingType.UpdatingTask:
                    return new UpdatingTask();

                case SendingType.RemovingTask:
                    return new RemovingTask();

                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}