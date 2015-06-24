namespace SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders
{
    using System.Collections.Generic;
    using DTO.ReportTemplate;

    public class MarginTableRender : TableRender
    {
        public MarginTableRender()
        {
        }

        public MarginTableRender(IRazor razor)
            : base(razor)
        {
        }

        public IList<MarginCustormer> Model { get; set; }

        public override string RenderTable()
        {
            var result = _razor.Parse(Template, Model);

            return result;
        }
    }
}