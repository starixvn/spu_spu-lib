namespace SPU.Lib.FraudDetection.MailSenders
{
    using MailMasterRenders;

    public interface IMailSender
    {
        IMailMasterRenderAbstractFactory MailMasterRenderAbstractFactory { get; set; }

        IMailClient MailClient { get; set; }

        void SendMail(int mailMasterId);
    }
}