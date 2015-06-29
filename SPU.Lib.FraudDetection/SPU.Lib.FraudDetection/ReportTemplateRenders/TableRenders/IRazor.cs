namespace SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders
{
    public interface IRazor
    {
        string Parse(string template, object model);
    }
}