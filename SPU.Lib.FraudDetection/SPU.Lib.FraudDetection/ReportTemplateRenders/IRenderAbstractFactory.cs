using System.Collections.Generic;
using System.Dynamic;
using SPU.Lib.FraudDetection.DTO.ReportTemplate;
using SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders;

namespace SPU.Lib.FraudDetection.ReportTemplateRenders
{
    public interface IReportRenderAbstractFactory
    {
        IReportTemplateRender GetReportTemplateRender();
    }

    public class SuspiciousStatisticReporRenderAbstractFactory : IReportRenderAbstractFactory
    {
        public SuspiciousStatisticViewModel SuspiciousStatisticViewModel { get; set; }

        public IList<string> Templates{ get; set; }

        public SuspiciousStatisticReporRenderAbstractFactory()
        {
            SuspiciousStatisticViewModel =new SuspiciousStatisticViewModel();
            Templates = new List<string>();
        }

        public IReportTemplateRender GetReportTemplateRender()
        {
            var suspiciousTableRender = new SuspiciousStatisticsTableRender
            {
                Model = SuspiciousStatisticViewModel.SuspiciousCustormers,
                Template = Templates[0],
            };

            var marginTableRender = new MarginTableRender
            {
                Model = SuspiciousStatisticViewModel.MarginCustormers,
                Template = Templates[1]
            };

            return new SuspiciousStatisticReportRender
            {
                TableRenders = new List<ITableRender>
                {
                    suspiciousTableRender,
                    marginTableRender
                }
            };
        }
    }
}