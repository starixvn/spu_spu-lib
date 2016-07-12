namespace FD.Lib.BusinessManager.MessageGenerator
{
    class MessageContentTypeMatchId : MessageContentType
    {
        public MessageContentTypeMatchId()
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
