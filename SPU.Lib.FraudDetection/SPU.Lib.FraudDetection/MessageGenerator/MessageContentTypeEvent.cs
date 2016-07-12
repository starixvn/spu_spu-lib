namespace FD.Lib.BusinessManager.MessageGenerator
{
    public class MessageContentTypeEvent : MessageContentType
    {
        public MessageContentTypeEvent() : base()
        {
            ContentTypeName = "";
        }

        protected override string FormatContentType(string messageContent)
        {
            if(messageContent.IndexOf(ContentTypeName) > 0)
            {

            }

            return messageContent;
        }
    }
}
