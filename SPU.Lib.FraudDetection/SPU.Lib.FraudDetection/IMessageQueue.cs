// --------------------------------------------------------------------------
// <copyright file="IMessageQueue.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace SPU.Lib.FraudDetection
{
    using System;
    using System.Messaging;

    /// <summary>
    /// Message Queue interface.
    /// </summary>
    public interface IMessageQueue
    {
        void AttachReceiveCompletedEventHandler(ReceiveCompletedEventHandler receiveCompleted);

        void DeattachReceiveCompletedEventHandler(ReceiveCompletedEventHandler receiveCompleted);

        void Send(object task);

        void Send(object task, string label);

        void Stop();

        void Clear();

        void BeginReceive();

        Message EndReceive(IAsyncResult asyncResult);
    }
}