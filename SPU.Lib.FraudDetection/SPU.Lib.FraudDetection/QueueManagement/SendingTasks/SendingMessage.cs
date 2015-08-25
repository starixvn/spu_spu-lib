// --------------------------------------------------------------------------
// <copyright file="SendingMessage.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.QueueManagement.SendingTasks
{
    public abstract class SendingMessage : ISendingMessage
    {
        private IMessageQueueSender _messageQueue;

        protected SendingMessage()
        {
            _messageQueue = new MessageQueueSender();
        }

        protected SendingMessage(IMessageQueueSender messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public SendingType Type { get; set; }

        public virtual bool Send(object message)
        {
            if (!IsValidMessage(message))
            {
                return false;
            }

            _messageQueue.Send(message, Type.ToString());

            return true;
        }

        protected virtual bool IsValidMessage(object message)
        {
            if (message == null)
            {
                return false;
            }

            int id;
            var result = int.TryParse(message.ToString(), out id);

            if (!result)
            {
                return false;
            }

            return id > 0;
        }
    }
}