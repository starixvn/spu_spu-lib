namespace FD.Lib.BusinessManager.MessageGenerator
{
    using FD.Lib.DTO;
    using System.Collections.Generic;

    public abstract class MessageContentType
    {
        public MessageContentType()
        {
        }

        protected string ContentTypeName { get; set; }

        public abstract List<Message> FormatContentType(List<Message> messages);
    }
}
