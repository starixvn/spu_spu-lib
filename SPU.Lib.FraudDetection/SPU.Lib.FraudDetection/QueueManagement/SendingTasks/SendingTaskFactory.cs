namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using System;

    /// <summary>
    ///     Sending Task Factory.
    /// </summary>
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

                case SendingType.DeactivateWorkflow:
                    return new DeactivatingWorkflow();

                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}