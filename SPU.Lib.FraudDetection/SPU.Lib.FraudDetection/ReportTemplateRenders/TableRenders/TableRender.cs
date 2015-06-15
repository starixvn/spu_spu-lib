namespace SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders
{
    public abstract class TableRender : ITableRender
    {
        protected IRazor _razor;

        protected TableRender()
        {
            _razor = new SpuRazor();
        }

        protected TableRender(IRazor razor)
        {
            _razor = razor;
        }

        public string Template { get; set; }

        public abstract string RenderTable();
    }
}