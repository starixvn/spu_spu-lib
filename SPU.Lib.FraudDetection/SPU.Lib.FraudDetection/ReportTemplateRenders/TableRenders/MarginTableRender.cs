using System.Collections.Generic;

namespace SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders
{
    public class MarginTableRender : TableRender
    {
        public MarginTableRender()
        {
        }

        public MarginTableRender(IRazor razor)
            : base(razor)
        {
        }

        public override string RenderTable()
        {
            var result = _razor.Parse(Template, Model);

            return result;
        }

        public IList<MarginCustormer> Model { get; set; }
    }
}