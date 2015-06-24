namespace SPU.Lib.FraudDetection.MailSenders
{
    using MailMasterRenders;

    public interface IMailSender
    {
        IMailMasterRenderAbstractFactory MailMasterRenderAbstractFactory { get; set; }
        void SendMail(int mailMasterId);
    }
}