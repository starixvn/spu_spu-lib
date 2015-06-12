// --------------------------------------------------------------------------
// <copyright file="IReceivingMessageHandler.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace SPU.Lib.FraudDetection
{
    using System.Messaging;

    /// <summary>
    /// Receiving Message Handler.
    /// </summary>
    public interface IReceivingMessageHandler
    {
        long ReceiveMessageCount { get; set; }

        void HandleReceivedMessage(object sender, ReceiveCompletedEventArgs e);

        void TriggerReceivingMessage();

        void ClearTasks();
    }
}