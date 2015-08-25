// --------------------------------------------------------------------------
// <copyright file="FDMessageQueue.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.QueueManagement
{
    using System;
    using System.Messaging;
    using Core.Utilities;
    using Fanex.Logging;

    /// <summary>
    ///     SPU Message Queue.
    /// </summary>
    public abstract class FDMessageQueue
    {
        protected readonly MessageQueue _messageQueue;

        protected FDMessageQueue()
        {
            var queuePath = ConfigSettings.GetConfigStringByName("queuePath");

            try
            {
                _messageQueue = new MessageQueue(queuePath) { Formatter = new XmlMessageFormatter(new[] { typeof(int) }) };
            }
            catch (InvalidOperationException ex)
            {
                Logger.Log.Error("_messageQueue = MessageQueue.Exists(queuePath) .. : " + ex);
            }
        }
    }
}