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

        public IReportRenderAbstractFactory ReportRenderAbstractFactory { get; set; }

        public IPlaceholderReplacer PlaceholderReplacer { get; set; }

        public MailMasterRender()
        {
            MailMasterService = new MailMasterService();
            PlaceholderReplacer = new PlaceholderReplacer();
        }

        public MailMasterRender(IReportRenderAbstractFactory renderAbstractFactory)
        {
            MailMasterService = new MailMasterService();
            PlaceholderReplacer = new PlaceholderReplacer();
            ReportRenderAbstractFactory = renderAbstractFactory;
        }
        
        public MailMasterRender(
            IMailMasterService mailMasterService,
            IReportRenderAbstractFactory renderAbstractFactory,
            IPlaceholderReplacer placeholderReplacer
            )
        {
            MailMasterService = mailMasterService;
            PlaceholderReplacer = placeholderReplacer;
            ReportRenderAbstractFactory = renderAbstractFactory;
        }

        public MailMasterInfo RenderContentOfMailMaster(int mailMasterId)
        {
            var mailMaster = MailMasterService.GetMailById(new MailMasterGetByIdCriteria { MailId = mailMasterId });

            var render = ReportRenderAbstractFactory.GetReportTemplateRender();

            var contentOfPlaceholder = render.RenderContent();

            var newMailContent = PlaceholderReplacer.ReplacePlaceholder(mailMaster.MailContent, contentOfPlaceholder);

            mailMaster.MailContent = newMailContent;

            return mailMaster;
        }
    }
}