// --------------------------------------------------------------------------
// <copyright file="SendingTaskFactory.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.SendingTasks
{
    using System;

    /// <summary>
    ///     Sending Task Factory.
    /// </summary>
    public class SendingTaskFactory
    {
        public static ISendingTask GetSender(SendingType type)
        {
            switch (type)
            {
                case SendingType.AddingTask:
                    return new AddingTask();

                case SendingType.UpdatingTask:
                    return new UpdatingTask();

                case SendingType.RemovingTask:
                    return new RemovingTask();

                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}