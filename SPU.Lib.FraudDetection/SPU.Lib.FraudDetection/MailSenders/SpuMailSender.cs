using Fanex.MailDelivery.Client.Handlers;
using Fanex.MailDelivery.Client.Models;
using SPU.Lib.FraudDetection.MailMasterRenders;

namespace SPU.Lib.FraudDetection.MailSenders
{
    public class SpuMailSender : IMailSender
    {
        public IMailMasterRenderAbstractFactory MailMasterRenderAbstractFactory { get; set; }

        public void SendMail(int mailMasterId)
        {
            var mailMasterRender = MailMasterRenderAbstractFactory.GetMailMasterRender();
            var mail = mailMasterRender.RenderContentOfMailMaster(mailMasterId);

            var newMail = new Mail
            {
                Subject = mail.MailSubject,
                Title = mail.MailSubject,
                Body = mail.MailContent,
                MailingListId = 80
            };

            MailClientHandler.Start();
            MailClientHandler.SendMail(newMail);
        }
    }
}