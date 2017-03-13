namespace FD.Lib.BusinessManager.MessageGenerator
{
    using FD.Lib.DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class MessageGenerator
    {
        private List<MessageContentType> _messageContentTypes;

        public MessageGenerator()
        {
            _messageContentTypes = new List<MessageContentType>();

            _messageContentTypes = Assembly.GetAssembly(
                typeof(MessageContentType)).GetTypes()
                .Where(t => t.IsSubclassOf(typeof(MessageContentType)))
                .Select(Activator.CreateInstance)
                .Cast<MessageContentType>().ToList();
        }

        public IEnumerable<Message> GenerateMessages(List<Message> messages)
        {
            foreach (MessageContentType contentType in _messageContentTypes)
            {
                contentType.FormatContentType(messages);
            }

            return messages;
        }
    }
}
