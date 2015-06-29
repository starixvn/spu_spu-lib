namespace SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders
{
    using RazorEngine;

    public class SpuRazor : IRazor
    {
        public string Parse(string template, object model)
        {
            return Razor.Parse(template, model);
        }
    }
}