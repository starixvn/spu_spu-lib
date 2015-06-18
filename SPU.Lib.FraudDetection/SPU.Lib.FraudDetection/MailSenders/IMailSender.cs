using Fanex.MailDelivery.Client.Handlers;
using Fanex.MailDelivery.Client.Models;
using SPU.Lib.FraudDetection.DTO.ReportTemplate;
using SPU.Lib.FraudDetection.MailMasterRenders;

namespace SPU.Lib.FraudDetection.MailSenders
{
    public interface IMailSender
    {
        IMailMasterRender MailMasterRender { get; set; }

        void SendMail(int mailMasterId, SuspiciousStatisticViewModel model);
    }

    public class SpuMailSender : IMailSender
    {
        public IMailMasterRender MailMasterRender { get; set; }

        public void SendMail(int mailMasterId, SuspiciousStatisticViewModel model)
        {
            var mail = MailMasterRender.RenderContentOfMailMaster(mailMasterId);

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