namespace FD.Lib.BusinessManager.MessageGenerator
{
    using FD.Lib.DTO;
    using System.Collections.Generic;

    class MessageContentTypeCaseName : MessageContentType
    {
        public MessageContentTypeCaseName()
            : base()
        {
            ContentTypeName = "";
        }

        public override List<Message> FormatContentType(List<Message> messages)
        {
            foreach (var message in messages)
            {
                if (message.MessageContent.IndexOf(ContentTypeName) > 0)
                {
                    message.MessageContent = message.MessageContent.Replace(ContentTypeName, message.CaseName);
                }
            }

            return messages;
        }
    }
}
