namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest.ReportTemplateRenders
{
    using System.Collections.Generic;
    using FraudDetection.ReportTemplateRenders;
    using FraudDetection.ReportTemplateRenders.TableRenders;
    using Moq;

    public class FakeSuspiciousStatisticReporRenderAbstractFactory : IReportRenderAbstractFactory
    {
        private const string contentOfMarginTable = "It's the content of margin table.";
        private const string contentOfSuspiciousStatisticTable = "It's the content of suspicious statistic table.";

        public IReportTemplateRender GetReportTemplateRender()
        {
            var mockTableRender1 = new Mock<ITableRender>();
            var mockTableRender2 = new Mock<ITableRender>();
            mockTableRender1.Setup(x => x.RenderTable()).Returns(contentOfMarginTable);
            mockTableRender2.Setup(x => x.RenderTable()).Returns(contentOfSuspiciousStatisticTable);

            return new SuspiciousStatisticReportRender
            {
                TableRenders = new List<ITableRender>
                {
                    mockTableRender1.Object,
                    mockTableRender2.Object
                }
            };
        }
    }
}