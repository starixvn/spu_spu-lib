namespace FD.Lib.BusinessManager.MessageGenerator
{
    using FD.Lib.DTO;
    using System.Collections.Generic;

    class MessageContentTypeMatchCode : MessageContentType
    {
        public MessageContentTypeMatchCode()
            : base()
        {
            ContentTypeName = "&lt;placeholder&gt;MatchCode&lt;/placeholder&gt;";
        }

        public override List<Message> FormatContentType(List<Message> messages)
        {
            foreach (var message in messages)
            {
                message.MessageContent = message.MessageContent.Replace(ContentTypeName, message.MatchCode);
            }

            return messages;
        }
    }
}
