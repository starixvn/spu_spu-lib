// --------------------------------------------------------------------------
// <copyright file="RemovingTask.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.SendingTasks
{
    using SPU.Lib.FraudDetection.BusinessManager;

    /// <summary>
    /// Removing Task.
    /// </summary>
    public class RemovingTask : SendingTask
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