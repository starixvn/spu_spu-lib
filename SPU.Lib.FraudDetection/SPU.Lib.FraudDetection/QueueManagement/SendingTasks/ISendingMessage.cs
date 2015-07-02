namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using DTO;

    /// <summary>
    ///     Sending Task Interface.
    /// </summary>
    public interface ISendingMessage
    {
        SendingType Type { get; set; }

        bool Send(object message);
    }
}