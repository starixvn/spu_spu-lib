namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using System;
    using SendingWorklows;

    /// <summary>
    ///     Sending Task Factory.
    /// </summary>
    public class SendingMessageFactory
    {
        public static ISendingMessage GetSender(SendingType type)
        {
            switch (type)
            {
                case SendingType.AddingTask:
                    return new AddingTask();

                case SendingType.UpdatingTask:
                    return new UpdatingTask();

                case SendingType.RemovingTask:
                    return new RemovingTask();

                case SendingType.DeactivatingWorkflow:
                    return new DeactivatingWorkflow();

                case SendingType.ActivatingWorkflow:
                    return new ActivatingWorkflow();

                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}