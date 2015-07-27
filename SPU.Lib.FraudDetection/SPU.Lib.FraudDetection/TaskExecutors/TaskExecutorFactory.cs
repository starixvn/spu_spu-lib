namespace SPU.Lib.FraudDetection.TaskExecutors
{
    using System;
    using Core.Utilities;
    using DTO;

    public class TaskExecutorFactory
    {
        public static TaskExecutor GetTaskExecutor(Task task)
        {
            var eventType = Utility.ParseEnum<EventType>(task.EventId.ToString());

            switch (eventType)
            {
                case EventType.ScanMatchAndFindTicket:
                    return new ScanMatchTaskExecutor(task);

                case EventType.CountSuspiciousTimesByCustomer:
                    return new CountingSuspicousTimesTaskExecutor(task);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}