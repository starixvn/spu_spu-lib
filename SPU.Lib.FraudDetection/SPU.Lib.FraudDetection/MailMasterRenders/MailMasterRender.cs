using System;
using System.Collections.Generic;
using SPU.Lib.FraudDetection.Criteria.MailMaster;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.ReportTemplateRenders;
using SPU.Lib.FraudDetection.Service.Implement;
using SPU.Lib.FraudDetection.Service.Interface;

namespace SPU.Lib.FraudDetection.MailMasterRenders
{
    public class MailMasterRender : IMailMasterRender
    {
        public IMailMasterService MailMasterService { get; set; }

        public IReportTemplateRender ReportTemplateRender { get; set; }

        public IPlaceholderReplacer PlaceholderReplacer { get; set; }

        public MailMasterRender()
        {
            MailMasterService = new MailMasterService();
            PlaceholderReplacer = new PlaceholderReplacer();
        }

        public MailMasterRender(IReportTemplateRender reportTemplateRender)
        {
            MailMasterService = new MailMasterService();
            PlaceholderReplacer = new PlaceholderReplacer();
            ReportTemplateRender = reportTemplateRender;
        }
        
        public MailMasterRender(
            IMailMasterService mailMasterService, 
            IReportTemplateRender reportTemplateRender,
            IPlaceholderReplacer placeholderReplacer
            )
        {
            MailMasterService = mailMasterService;
            PlaceholderReplacer = placeholderReplacer;
            ReportTemplateRender = reportTemplateRender;
        }

        public MailMasterInfo RenderContentOfMailMaster(int mailMasterId)
        {
            var mailMaster = MailMasterService.GetMailById(new MailMasterGetByIdCriteria { MailId = mailMasterId });

            var contentOfPlaceholder = ReportTemplateRender.RenderContent();

            var newMailContent = PlaceholderReplacer.ReplacePlaceholder(mailMaster.MailContent, contentOfPlaceholder);

            mailMaster.MailContent = newMailContent;

            return mailMaster;
        }
    }
}