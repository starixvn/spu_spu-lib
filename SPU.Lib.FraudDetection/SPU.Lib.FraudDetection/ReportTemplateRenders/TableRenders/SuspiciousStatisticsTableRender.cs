using System.Collections.Generic;
using SPU.Lib.FraudDetection.DTO.ReportTemplate;

namespace SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders
{
    public class SuspiciousStatisticsTableRender : TableRender
    {
        public IList<SuspiciousCustormer> Model { get; set; }

        public SuspiciousStatisticsTableRender()
        {
        }

        public SuspiciousStatisticsTableRender(IRazor razor)
            : base(razor)
        {
        }

        public override string RenderTable()
        {
            var result = _razor.Parse(Template, Model);

            return result;
        }
    }
}