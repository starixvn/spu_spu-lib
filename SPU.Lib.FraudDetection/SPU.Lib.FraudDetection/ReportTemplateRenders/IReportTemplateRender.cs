using System.Collections.Generic;
using SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders;

namespace SPU.Lib.FraudDetection.ReportTemplateRenders
{
    public interface IReportTemplateRender
    {
        IList<ITableRender> TableRenders { get; set; }

        string RenderContent();
    }
}