namespace FD.Lib.BusinessManager.MessageGenerator
{
    using FD.Lib.DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MessageGenerator
    {
        private List<MessageContentType> MessageContentTypes;

        public MessageGenerator()
        {
            MessageContentTypes = new List<MessageContentType>();

            var derivedTypes = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(MessageContentType))).ToList();

            foreach(var derivedType in derivedTypes)
            {
                MessageContentTypes.Add((MessageContentType)Activator.CreateInstance(derivedType));
            }
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
