using System.Messaging;

namespace SPU.Lib.FraudDetection
{
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