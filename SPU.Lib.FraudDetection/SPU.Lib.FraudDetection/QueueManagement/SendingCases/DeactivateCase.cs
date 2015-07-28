// --------------------------------------------------------------------------
// <copyright file="DeactivatingCase.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.QueueManagement.SendingWorklows
{
    using QueueManagement;
    using SendingTasks;

    public class DeactivatingCase : SendingMessage
    {
        public DeactivatingCase()
        {
            Type = SendingType.DeactivatingCase;
        }

        protected DeactivatingCase(IMessageQueue messageQueue)
            : base(messageQueue)
        {
            Type = SendingType.DeactivatingCase;
        }
    }
}