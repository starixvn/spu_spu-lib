namespace SPU.Lib.FraudDetection.MailSenders
{
    using Fanex.MailDelivery.Client.Handlers;
    using Fanex.MailDelivery.Client.Models;

    public interface IMailClient
    {
        void Send(Mail mail);
    }

    public class MailClient : IMailClient
    {
        public void Send(Mail mail)
        {
            MailClientHandler.Start();
            MailClientHandler.SendMail(mail);
        }
    }
}