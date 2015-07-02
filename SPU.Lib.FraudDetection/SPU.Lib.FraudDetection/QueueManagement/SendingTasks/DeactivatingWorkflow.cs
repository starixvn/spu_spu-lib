namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using System;
    using QueueManagement;

    public class DeactivatingWorkflow : SendingMessage
    {
        public DeactivatingWorkflow()
        {
            Type = SendingType.DeactivateWorkflow;
        }

        protected DeactivatingWorkflow(IMessageQueue messageQueue):base(messageQueue)
        {
            Type = SendingType.DeactivateWorkflow;
        }

        public virtual bool Send(int workflowId)
        {
            if (workflowId <= 0)
            {
                return false;
            }

            _messageQueue.Send(workflowId, Type.ToString());

            return true;
        }

        public override bool Send(object message)
        {
            if (!IsValidMessage(message))
            {
                return false;
            }

            var workflowId = int.Parse(message.ToString());

            _messageQueue.Send(workflowId, Type.ToString());

            return true;
        }

        protected override bool IsValidMessage(object message)
        {
            if (!(message is int))
            {
                return false;
            }

            var workflowId = int.Parse(message.ToString());

            return workflowId > 0;
        }
    }
}