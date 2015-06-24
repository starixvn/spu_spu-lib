namespace SPU.Lib.FraudDetection.ReportTemplateRenders
{
    using System.Collections.Generic;
    using System.Text;
    using TableRenders;

    public class SuspiciousStatisticReportRender : IReportTemplateRender
    {
        public IList<ITableRender> TableRenders { get; set; }

        public string RenderContent()
        {
            var builder = new StringBuilder();

            foreach (var tableRender in TableRenders)
            {
                var tableHtml = tableRender.RenderTable();
                builder.Append(tableHtml);
                builder.Append("<p/>");
            }

            var result = builder.ToString();

            return result;
        }
    }

    public enum ReportTemplateType
    {
        SuspiciousStatistic,
        FakeSuspiciousStatistic
    }
}