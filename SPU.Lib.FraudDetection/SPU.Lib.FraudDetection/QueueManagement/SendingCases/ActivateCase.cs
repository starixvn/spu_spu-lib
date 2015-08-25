// --------------------------------------------------------------------------
// <copyright file="ActivatingCase.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.QueueManagement.SendingTasks
{
    using QueueManagement;

    public class ActivatingCase : SendingMessage
    {
        public ActivatingCase()
        {
            Type = SendingType.ActivatingCase;
        }

        protected ActivatingCase(IMessageQueueSender messageQueue)
            : base(messageQueue)
        {
            Type = SendingType.DeactivatingCase;
        }
    }
}