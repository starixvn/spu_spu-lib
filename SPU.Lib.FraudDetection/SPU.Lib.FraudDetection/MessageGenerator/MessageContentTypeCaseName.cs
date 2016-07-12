namespace FD.Lib.BusinessManager.MessageGenerator
{
    class MessageContentTypeCaseName : MessageContentType
    {
        public MessageContentTypeCaseName()
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
