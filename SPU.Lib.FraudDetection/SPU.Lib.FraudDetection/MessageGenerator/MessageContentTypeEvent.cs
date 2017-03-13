namespace FD.Lib.BusinessManager.MessageGenerator
{
    using FD.Lib.DTO;
    using System.Collections.Generic;

    public class MessageContentTypeEvent : MessageContentType
    {
        public MessageContentTypeEvent() : base()
        {
            ContentTypeName = "&lt;placeholder&gt;TeamAvsTeamB&lt;/placeholder&gt;";
        }

        public override List<Message> FormatContentType(List<Message> messages)
        {
            foreach (var message in messages)
            {
                message.MessageContent = message.MessageContent.Replace(ContentTypeName, message.Event);
            }

            return messages;
        }
    }
}
