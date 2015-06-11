using SPU.Lib.FraudDetection.BusinessManager;

namespace SPU.Lib.FraudDetection.SendingTasks
{
    public interface ISendingTask
    {
        SendingType Type { get; set; }

        bool Send(Task newTask);
    }
}