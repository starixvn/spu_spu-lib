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
                var message = msg.Body;
                var id = (int)message;

                if (string.IsNullOrEmpty(msg.Label))
                {
                    return;
                }

                var type = ConvertLabelIntoSendingType(msg);

                switch (type)
                {
                    case SendingType.AddingTask:
#if DEBUG
                        Console.WriteLine("AddingTask: {0}", id);
#endif

                        _taskManager.AddTask(id);
                        break;

                    case SendingType.UpdatingTask:
#if DEBUG
                        Console.WriteLine("UpdatingTask: {0}", id);
#endif

                        _taskManager.UpdateTask(id);
                        break;

                    case SendingType.RemovingTask:
#if DEBUG
                        Console.WriteLine("RemovingTask: {0}{0}", id);
#endif

                        _taskManager.RemoveTask(id);
                        break;

                    case SendingType.DeactivatingCase:
#if DEBUG
                        Console.WriteLine("DeactivateCase: {0}", id);
#endif
                        _taskManager.RemoveTasksInCase(id);
                        break;
                    case SendingType.ActivatingCase:
#if DEBUG
                        Console.WriteLine("ActivateCase: {0}", id);
#endif
                        _taskManager.AddTasksInCase(id);
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