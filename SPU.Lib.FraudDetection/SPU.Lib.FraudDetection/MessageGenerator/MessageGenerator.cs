namespace FD.Lib.BusinessManager.MessageGenerator
{
    using FD.Lib.DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class MessageGenerator
    {
        private List<MessageContentType> MessageContentTypes;

        public MessageGenerator()
        {
            MessageContentTypes = new List<MessageContentType>();

            MessageContentTypes = Assembly.GetAssembly(typeof(MessageContentType)).GetTypes().Where(t => t.IsSubclassOf(typeof(MessageContentType))).Select(Activator.CreateInstance).Cast<MessageContentType>().ToList();
        }

        public IEnumerable<Message> GenerateMessages(List<Message> messages)
        {
            foreach(MessageContentType contentType in MessageContentTypes)
            {
                contentType.FormatContentType(messages);
            }

            return messages;
        }
    }
}
