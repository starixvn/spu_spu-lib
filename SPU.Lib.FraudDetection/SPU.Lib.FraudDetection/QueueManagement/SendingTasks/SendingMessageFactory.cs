// --------------------------------------------------------------------------
// <copyright file="SendingMessageFactory.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.QueueManagement.SendingTasks
{
    using System;
    using SendingWorklows;

    /// <summary>
    ///     Sending Task Factory.
    /// </summary>
    public class SendingMessageFactory
    {
        public static ISendingMessage GetSender(SendingType type)
        {
            switch (type)
            {
                case SendingType.AddingTask:
                    return new AddingTask();

                case SendingType.UpdatingTask:
                    return new UpdatingTask();

                case SendingType.RemovingTask:
                    return new RemovingTask();

                case SendingType.DeactivatingCase:
                    return new DeactivatingCase();

                case SendingType.ActivatingCase:
                    return new ActivatingCase();

                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}