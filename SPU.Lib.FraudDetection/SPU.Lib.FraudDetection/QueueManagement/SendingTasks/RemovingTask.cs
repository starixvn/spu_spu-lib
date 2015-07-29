// --------------------------------------------------------------------------
// <copyright file="RemovingTask.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.QueueManagement.SendingTasks
{
    using QueueManagement;

    /// <summary>
    ///     Removing Task.
    /// </summary>
    public class RemovingTask : SendingMessage
    {
        public RemovingTask()
        {
            Type = SendingType.RemovingTask;
        }

        public RemovingTask(IMessageQueue messageQueue)
            : base(messageQueue)
        {
            Type = SendingType.RemovingTask;
        }
    }
}