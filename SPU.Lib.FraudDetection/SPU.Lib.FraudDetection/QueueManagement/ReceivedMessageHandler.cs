namespace SPU.Lib.FraudDetection.QueueManagement
{
    using System;
    using System.Messaging;
    using DTO;
    using SendingTasks;
    using TaskExecutors;

    /// <summary>
    ///     Receiving Message Handler.
    /// </summary>
    public class ReceivingMessageHandler : IReceivingMessageHandler
    {
        private readonly IMessageQueue _queue;
        private readonly ITaskManager _taskManager;

        public ReceivingMessageHandler()
        {
            _taskManager = new TaskManager();
            _queue = new SpuMessageQueue();
            _queue.AttachReceiveCompletedEventHandler(HandleReceivedMessage);
        }

        public ReceivingMessageHandler(ITaskManager taskManager, IMessageQueue queue)
        {
            _taskManager = taskManager;
            _queue = queue;
            _queue.AttachReceiveCompletedEventHandler(HandleReceivedMessage);
        }

        public void HandleReceivedMessage(object sender, ReceiveCompletedEventArgs e)
        {
            using (var msg = _queue.EndReceive(e.AsyncResult))
            {
                var task = msg.Body as Task;

                if (string.IsNullOrEmpty(msg.Label) || task == null)
                {
                    return;
                }

                var type = ConvertLabelIntoSendingType(msg);

                switch (type)
                {
                    case SendingType.AddingTask:
#if DEBUG
                        Console.WriteLine("AddingTask: {0} - {1} - {2}", task.WorkflowId, task.TaskId, task.TaskName);
#endif

                        _taskManager.AddTask(task);
                        break;

                    case SendingType.UpdatingTask:
#if DEBUG
                        Console.WriteLine("UpdatingTask: {0} - {1} - {2}", task.WorkflowId, task.TaskId, task.TaskName);
#endif

                        _taskManager.UpdateTask(task);
                        break;

                    case SendingType.RemovingTask:
#if DEBUG
                        Console.WriteLine("RemovingTask: {0} - {1} - {2}", task.WorkflowId, task.TaskId, task.TaskName);
#endif

                        _taskManager.RemoveTask(task);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            _queue.BeginReceive();
        }

        public void TriggerReceivingMessage()
        {
            _queue.BeginReceive();
        }

        public void ClearTasks()
        {
            _taskManager.ClearTasks();
            _queue.DeattachReceiveCompletedEventHandler(HandleReceivedMessage);
        }

        private SendingType ConvertLabelIntoSendingType(Message msg)
        {
            SendingType type;
            var result = Enum.TryParse(msg.Label, true, out type);

            return result ? type : SendingType.None;
        }
    }
}