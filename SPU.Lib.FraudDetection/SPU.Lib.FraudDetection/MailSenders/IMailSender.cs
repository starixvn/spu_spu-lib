using Fanex.MailDelivery.Client.Handlers;
using Fanex.MailDelivery.Client.Models;
using SPU.Lib.FraudDetection.MailMasterRenders;

namespace SPU.Lib.FraudDetection.MailSenders
{
    public interface IMailSender
    {
        IMailMasterRender MailMasterRender { get; set; }

        void SendMail();
    }

    public class SpuMailSender : IMailSender
    {
        public IMailMasterRender MailMasterRender { get; set; }

        public void SendMail()
        {
            var mail = MailMasterRender.RenderContentOfMailMaster();

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