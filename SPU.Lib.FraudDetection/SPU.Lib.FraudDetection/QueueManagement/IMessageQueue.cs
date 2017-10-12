// --------------------------------------------------------------------------
// <copyright file="IMessageQueue.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.QueueManagement
{
    public interface IMessageQueueSender
    {
        void Clear();

        void Send(object task);

        void Send(object task, string label);
    }

    public class MessageQueueSender : FDMessageQueue, IMessageQueueSender
    {
        public void Clear()
        {
            _messageQueue.Purge();
        }

        public void Send(object task)
        {
            _messageQueue.Send(task);
        }

        public void Send(object task, string label)
        {
            _messageQueue.Send(task, label);
        }
    }
}