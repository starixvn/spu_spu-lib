namespace FD.Lib.BusinessManager.MessageGenerator
{
    using FD.Lib.DTO;
    using System.Collections.Generic;

    class MessageContentTypeCaseName : MessageContentType
    {
        public MessageContentTypeCaseName()
            : base()
        {
            ContentTypeName = "&lt;placeholder&gt;FraudCaseName&lt;/placeholder&gt;";
        }

        public override List<Message> FormatContentType(List<Message> messages)
        {
            foreach (var message in messages)
            {
                message.MessageContent = message.MessageContent.Replace(ContentTypeName, message.CaseName);
            }

            return messages;
        }
    }
}
