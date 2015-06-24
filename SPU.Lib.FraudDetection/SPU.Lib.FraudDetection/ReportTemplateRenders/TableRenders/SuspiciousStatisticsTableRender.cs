namespace SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders
{
    using System.Collections.Generic;
    using DTO.ReportTemplate;

    public class SuspiciousStatisticsTableRender : TableRender
    {
        public SuspiciousStatisticsTableRender()
        {
        }

        public SuspiciousStatisticsTableRender(IRazor razor)
            : base(razor)
        {
        }

        public IList<SuspiciousCustormer> Model { get; set; }

        public override string RenderTable()
        {
            var result = _razor.Parse(Template, Model);

            return result;
        }
    }
}