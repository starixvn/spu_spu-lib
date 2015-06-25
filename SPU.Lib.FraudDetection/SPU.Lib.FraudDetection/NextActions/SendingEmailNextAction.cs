namespace SPU.Lib.FraudDetection.NextActions
{
    using System.Collections.Generic;
    using DTO;
    using MailMasterRenders;
    using MailSenders;
    using ReportTemplateRenders;
    using Service.Implement;
    using Service.Interface;

    /// <summary>
    ///     ActionSendEmail Class.
    /// </summary>
    public class SendingEmailNextAction : INextAction
    {
        public int MailMasterId { get; set; }

        public IList<SuspiciousInfo> SuspicionList { get; set; }

        public IMailSender MailSender { get; set; }

        public IReportService ReportService { get; set; }

        public SendingEmailNextAction(int mailMasterId)
        {
            MailMasterId = mailMasterId;
            MailSender = new SpuMailSender();
            ReportService = new ReportService();
        }

        public SendingEmailNextAction(int mailMasterId, IMailSender mailSender, IReportService reportService)
        {
            MailMasterId = mailMasterId;
            MailSender = mailSender;
            ReportService = reportService;
        }

        public void TakeAction()
        {
            if (SuspicionList.Count <= 0)
            {
                return;
            }

            var model = ReportService.GetSuspiciousCustomerStatistics(SuspicionList);

            var renderFactory = new SuspiciousStatisticReporRenderAbstractFactory
            {
                SuspiciousStatisticViewModel = model
            };

            var mailMasterRenderAbstractFactory = new MailMasterRenderAbstractFactory
            {
                ReportRenderFactory = renderFactory
            };

            MailSender.MailMasterRenderAbstractFactory = mailMasterRenderAbstractFactory;

            MailSender.SendMail(MailMasterId);
        }
    }
}