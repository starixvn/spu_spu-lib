using RazorEngine;

namespace SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders
{
    public interface IRazor
    {
        string Parse(string template, object model);
    }

    public class SpuRazor : IRazor
    {
        public string Parse(string template, object model)
        {
            return Razor.Parse(template, model);
        }
    }
}