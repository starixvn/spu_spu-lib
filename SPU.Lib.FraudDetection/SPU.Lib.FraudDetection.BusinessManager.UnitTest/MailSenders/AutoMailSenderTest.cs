using System.Collections.Generic;
using System.IO;
using Fanex.Data.Configuration;
using Moq;
using NUnit.Framework;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.DTO.ReportTemplate;
using SPU.Lib.FraudDetection.MailMasterRenders;
using SPU.Lib.FraudDetection.MailSenders;
using SPU.Lib.FraudDetection.ReportTemplateRenders;
using SPU.Lib.FraudDetection.Service.Implement;

namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest.MailSenders
{
    [TestFixture]
    public class SpuMailSenderTest
    {
        private const string MarginTemplateFilePath = @"..\..\..\SPU.Lib.FraudDetection\ReportTemplateRenders\TableTemplates\MarginReport.cshtml";
        private const string SuspiciousTemplateFilePath = @"..\..\..\SPU.Lib.FraudDetection\ReportTemplateRenders\TableTemplates\SuspiciousStatisticsReport.cshtml";

        [SetUp]
        public void SetUp()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]
        public void When_Calling_Send_Mail_Then_RenderContent_Should_Be_Called()
        {
            const string partialContent = "Suspicious Statistic Table and Margin Table"; 
            var sut = new SpuMailSender();

            var mockReportTemplateRender = new Mock<IReportTemplateRender>();
            var mockMailMasterRender = new MailMasterRender(mockReportTemplateRender.Object);

            sut.MailMasterRender = mockMailMasterRender;

            mockReportTemplateRender.Setup(x => x.RenderContent()).Returns(partialContent);

            sut.SendMail(10, null);

            mockReportTemplateRender.Verify(x => x.RenderContent(), Times.Exactly(1));
        }

        [Test]
        public void Test_Intergrating_Mail_Master_Into_System()
        {
            DbSettingProviderManager.Current.Start();

            var sut = new SpuMailSender();

            var model = GetSampleData();

            var templates = new List<string>
            {
                File.ReadAllText(SuspiciousTemplateFilePath),
                File.ReadAllText(MarginTemplateFilePath)
            };

            var renderFactory = new SuspiciousStatisticReporRenderAbstractFactory
            {
                SuspiciousStatisticViewModel = model,
                Templates = templates
            };

            var reportRender = renderFactory.GetReportTemplateRender();

            var mockMailMasterRender = new MailMasterRender
            {
                ReportTemplateRender = reportRender
            };

            sut.MailMasterRender = mockMailMasterRender;

            sut.SendMail(10, model);
        }

        private SuspiciousStatisticViewModel GetSampleData()
        {
            var sut = new ReportService();

            var list = new List<SuspiciousInfo>
            {
                new SuspiciousInfo
                {
                    CustId = 1280,
                    MatchId = 13606626
                },
                new SuspiciousInfo
                {
                    CustId = 1280,
                    MatchId = 13659022
                },
                new SuspiciousInfo
                {
                    CustId = 1280,
                    MatchId = 13675244
                },
            };

            return sut.GetSuspiciousCustomerStatistics(list);
        }
    }
}