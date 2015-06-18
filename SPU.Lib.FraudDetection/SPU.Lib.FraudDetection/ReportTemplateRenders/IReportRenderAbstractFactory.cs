namespace SPU.Lib.FraudDetection.ReportTemplateRenders
{
    public interface IReportRenderAbstractFactory
    {
        IReportTemplateRender GetReportTemplateRender();
    }
}