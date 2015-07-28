// --------------------------------------------------------------------------
// <copyright file="AddingTask.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.QueueManagement.SendingTasks
{
    using QueueManagement;

    public class AddingTask : SendingMessage
    {
        public AddingTask()
        {
            Type = SendingType.AddingTask;
        }

        public AddingTask(IMessageQueue messageQueue)
            : base(messageQueue)
        {
            Type = SendingType.AddingTask;
        }
    }
}