namespace SPU.Lib.FraudDetection.MailSenders
{
    using Fanex.MailDelivery.Client.Handlers;
    using Fanex.MailDelivery.Client.Models;
    using MailMasterRenders;

    public class SpuMailSender : IMailSender
    {
        public IMailMasterRenderAbstractFactory MailMasterRenderAbstractFactory { get; set; }

        public IMailClient MailClient { get; set; }

        public SpuMailSender()
        {
            MailClient = new MailClient();
        }

        public SpuMailSender(IMailClient client)
        {
            MailClient = client;
        }

        public void SendMail(int mailMasterId)
        {
            var mailMasterRender = MailMasterRenderAbstractFactory.GetMailMasterRender();
            var mail = mailMasterRender.RenderContentOfMailMaster(mailMasterId);

            ////FileWriter.WriteFile(mail.MailContent);

            var newMail = new Mail
            {
                Subject = mail.MailSubject,
                Title = mail.MailSubject,
                Body = mail.MailContent,
                MailingListId = 80
            };

            MailClient.Send(newMail);
        }
    }
}