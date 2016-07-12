namespace FD.Lib.BusinessManager.MessageGenerator
{
    using FD.Lib.DTO;
    using System.Collections.Generic;

    public class MessageContentType
    {
        protected string ContentTypeName { get; set; }

        protected List<Message> MessageList;

        public MessageContentType()
        {
        }

        protected abstract string FormatContentType(string messageContent)
        {
            return messageContent;
        }
    }
}
