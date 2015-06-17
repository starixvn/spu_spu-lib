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
        public int MailMasterId { get; set; }

        private IMailMasterService _mailMasterService;

        private IReportTemplateRender _reportTemplateRender;

        private IPlaceholderReplacer _placeholderReplacer;

        public MailMasterRender()
        {
            _mailMasterService = new MailMasterService();
            _placeholderReplacer = new PlaceholderReplacer();
        }

        public MailMasterRender(IReportTemplateRender reportTemplateRender)
        {
            _mailMasterService = new MailMasterService();
            _placeholderReplacer = new PlaceholderReplacer();
            _reportTemplateRender = reportTemplateRender;
        }
        
        public MailMasterRender(
            IMailMasterService mailMasterService, 
            IReportTemplateRender reportTemplateRender,
            IPlaceholderReplacer placeholderReplacer
            )
        {
            _mailMasterService = mailMasterService;
            _placeholderReplacer = placeholderReplacer;
            _reportTemplateRender = reportTemplateRender;
        }

        public MailMasterInfo RenderContentOfMailMaster()
        {
            var mailMaster = _mailMasterService.GetMailById(new MailMasterGetByIdCriteria{ MailId = MailMasterId});

            var contentOfPlaceholder = _reportTemplateRender.RenderContent();

            var newMailContent = _placeholderReplacer.ReplacePlaceholder(mailMaster.MailContent, contentOfPlaceholder);

            mailMaster.MailContent = newMailContent;

            return mailMaster;
        }
    }
}