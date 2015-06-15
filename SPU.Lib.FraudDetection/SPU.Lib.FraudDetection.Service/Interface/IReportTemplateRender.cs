namespace SPU.Lib.FraudDetection.Service.Interface
{
    public interface IReportTemplateRender
    {
        string RenderContent();
    }

    public class SuspiciousStatisticReportRender : IReportTemplateRender
    {
        public dynamic Data { get; set; }

        public string RenderContent()
        {
            throw new System.NotImplementedException();
        }
    }
}