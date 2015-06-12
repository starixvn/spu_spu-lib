using System;
using System.Messaging;
using SPU.Lib.FraudDetection.BusinessManager;
using SPU.Lib.FraudDetection.SendingTasks;

namespace SPU.Lib.FraudDetection
{
    public class ReceivingMessageHandler : IReceivingMessageHandler
    {
        private readonly IMessageQueue _queue;
        private readonly ITaskManager _taskManager;

        public ReceivingMessageHandler()
        {
            _taskManager = new TaskManager();
            _queue = new SpuMessageQueue();
        }

        public ReceivingMessageHandler(ITaskManager taskManager, IMessageQueue queue)
        {
            _taskManager = taskManager;
            _queue = queue;
        }

        public void HandleReceivedMessage(object sender, ReceiveCompletedEventArgs e)
        {
            using (var msg = _queue.EndReceive(e.AsyncResult))
            {
                var task = msg.Body as Task;

                if (string.IsNullOrEmpty(msg.Label))
                {
                    return;
                }

                var type = ConvertLabelIntoSendingType(msg);

                switch (type)
                {
                    case SendingType.AddingTask:
                        _taskManager.AddTask(task);
                        break;

                    case SendingType.UpdatingTask:
                        _taskManager.UpdateTask(task);
                        break;

                    case SendingType.RemovingTask:
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
            _queue.ReceiveCompleted += HandleReceivedMessage;
            _queue.BeginReceive();
        }

        private SendingType ConvertLabelIntoSendingType(Message msg)
        {
            SendingType type;
            var result = Enum.TryParse(msg.Label, true, out type);

            return result ? type : SendingType.None;
        }
    }
}