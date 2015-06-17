using System;
using SPU.Lib.FraudDetection.ReportTemplateRenders;
using SPU.Lib.FraudDetection.Service.Implement;
using SPU.Lib.FraudDetection.Service.Interface;


namespace SPU.Lib.FraudDetection.MailMasterRenders
{
    public interface IMailMasterRender
    {
        int MailMasterId { get; set; }
        string GetContent();
    }

    public class MailMasterRender : IMailMasterRender
    {
        public int MailMasterId { get; set; }

        private IMailMasterService _mailMasterService;

        private IReportTemplateRender _reportTemplateRender;

        public MailMasterRender()
        {
            _mailMasterService = new MailMasterService();
        }

        public MailMasterRender(IReportTemplateRender reportTemplateRender)
        {
            _mailMasterService = new MailMasterService();
            _reportTemplateRender = reportTemplateRender;
        }
        
        public MailMasterRender(IMailMasterService mailMasterService, IReportTemplateRender reportTemplateRender)
        {
            _mailMasterService = mailMasterService;
            _reportTemplateRender = reportTemplateRender;
        }

        public string GetContent()
        {
            throw new NotImplementedException();
        }
    }
}