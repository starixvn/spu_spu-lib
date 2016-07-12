namespace FD.Lib.BusinessManager.MessageGenerator
{
    class MessageContentTypeMatchCode : MessageContentType
    {
        public MessageContentTypeMatchCode()
            : base()
        {
            ContentTypeName = "";
        }

        protected override string FormatContentType(string messageContent)
        {
            throw new System.NotImplementedException();
        }
    }
}
