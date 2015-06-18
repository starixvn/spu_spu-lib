using System;
using SPU.Lib.FraudDetection.ReportTemplateRenders;

namespace SPU.Lib.FraudDetection.MailMasterRenders
{
    public interface IMailMasterRenderAbstractFactory
    {
        IMailMasterRender GetMailMasterRender();
    }

    public class MailMasterRenderAbstractFactory : IMailMasterRenderAbstractFactory
    {
        public IReportRenderAbstractFactory ReportRenderFactory { get; set; }

        public IMailMasterRender GetMailMasterRender()
        {
            return new MailMasterRender(ReportRenderFactory);
        }
    }
}
