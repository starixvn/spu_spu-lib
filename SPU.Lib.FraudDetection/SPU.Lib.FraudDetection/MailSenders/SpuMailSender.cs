// --------------------------------------------------------------------------
// <copyright file="SpuMailSender.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.MailSenders
{
    using Fanex.MailDelivery.Client.Models;
    using MailMasterRenders;

    public class SpuMailSender : IMailSender
    {
        public SpuMailSender()
        {
            MailClient = new MailClient();
        }

        public SpuMailSender(IMailClient client)
        {
            MailClient = client;
        }

        public IMailMasterRenderAbstractFactory MailMasterRenderAbstractFactory { get; set; }

        public IMailClient MailClient { get; set; }

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