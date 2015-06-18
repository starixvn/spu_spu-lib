using SPU.Lib.FraudDetection.MailMasterRenders;

namespace SPU.Lib.FraudDetection.MailSenders
{
    public interface IMailSender
    {
        IMailMasterRenderAbstractFactory MailMasterRenderAbstractFactory { get; set; }

        void SendMail(int mailMasterId);
    }
}