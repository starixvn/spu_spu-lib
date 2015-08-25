// --------------------------------------------------------------------------
// <copyright file="DeactivatingCase.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.QueueManagement.SendingWorklows
{
    using QueueManagement;
    using SendingTasks;

    public class DeactivatingCase : SendingMessage
    {
        public DeactivatingCase()
        {
            Type = SendingType.DeactivatingCase;
        }

        protected DeactivatingCase(IMessageQueueSender messageQueue)
            : base(messageQueue)
        {
            Type = SendingType.DeactivatingCase;
        }
    }
}