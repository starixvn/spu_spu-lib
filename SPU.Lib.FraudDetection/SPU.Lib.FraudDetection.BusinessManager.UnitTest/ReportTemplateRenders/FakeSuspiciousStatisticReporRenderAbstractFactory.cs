using System;
using System.Collections.Generic;
using Moq;
using SPU.Lib.FraudDetection.ReportTemplateRenders;
using SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders;

namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest.ReportTemplateRenders
{
    public class FakeSuspiciousStatisticReporRenderAbstractFactory : IReportRenderAbstractFactory
    {
        const string contentOfMarginTable = "It's the content of margin table.";
        const string contentOfSuspiciousStatisticTable = "It's the content of suspicious statistic table.";

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