// --------------------------------------------------------------------------
// <copyright file="MessageQueueExtension.cs" company="Nexcel Solutions Vietnam">
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
    /// Message Queue Extension.
    /// </summary>
    public static class MessageQueueExtension
    {
        public static int GetMessageCount(this MessageQueue source)
        {
            var filter = new MessagePropertyFilter()
            {
                AdministrationQueue = false,
                ArrivedTime = false,
                CorrelationId = false,
                Priority = false,
                ResponseQueue = false,
                SentTime = false,
                Body = false,
                Label = false,
                Id = false
            };

            source.MessageReadPropertyFilter = filter;

            return source.GetAllMessages().Length;
        }
    }
}