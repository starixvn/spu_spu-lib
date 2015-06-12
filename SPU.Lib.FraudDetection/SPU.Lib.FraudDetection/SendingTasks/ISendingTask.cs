// --------------------------------------------------------------------------
// <copyright file="ISendingTask.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.SendingTasks
{
    using BusinessManager;

    /// <summary>
    /// Sending Task Interface.
    /// </summary>
    public interface ISendingTask
    {
        SendingType Type { get; set; }

        bool Send(Task newTask);
    }
}