namespace SPU.Lib.FraudDetection.ReportTemplateRenders
{
    using System.Collections.Generic;
    using TableRenders;

    public interface IReportTemplateRender
    {
        IList<ITableRender> TableRenders { get; set; }
        string RenderContent();
    }
}