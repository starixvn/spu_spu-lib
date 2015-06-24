namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using DTO;

    /// <summary>
    ///     Sending Task Interface.
    /// </summary>
    public interface ISendingTask
    {
        SendingType Type { get; set; }
        bool Send(Task newTask);
    }
}