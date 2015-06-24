namespace SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders
{
    public interface ITableRender
    {
        string Template { get; set; }
        string RenderTable();
    }
}