namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest.MailSenders
{
    using System.Collections.Generic;
    using DTO;
    using DTO.ReportTemplate;
    using Fanex.Data.Configuration;
    using FraudDetection.MailMasterRenders;
    using FraudDetection.MailSenders;
    using FraudDetection.ReportTemplateRenders;
    using Mock_Objects;
    using Moq;
    using NUnit.Framework;
    using Service.Implement;

    [TestFixture]
    public class SpuMailSenderTest
    {
        [SetUp]
        public void SetUp()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]
        public void When_Calling_Send_Mail_Then_RenderContent_Should_Be_Called()
        {
            // --- Arrange --
            const string partialContent = "Suspicious Statistic Table and Margin Table";
            var reporRenderAbstractFactory = new Mock<IReportRenderAbstractFactory>();
            var mockMailRender = new Mock<IReportTemplateRender>();
            var mockMailRenderAbstractFactory = new Mock<IMailMasterRenderAbstractFactory>();
            var mockMailMasterRender = new MailMasterRender(reporRenderAbstractFactory.Object);
            reporRenderAbstractFactory.Setup(x => x.GetReportTemplateRender()).Returns(mockMailRender.Object);
            mockMailRenderAbstractFactory.Setup(x => x.GetMailMasterRender()).Returns(mockMailMasterRender);
            mockMailRender.Setup(x => x.RenderContent()).Returns(partialContent);

            // --- Act --
            var sut = new SpuMailSender(new FakeMailClient())
            {
                MailMasterRenderAbstractFactory = mockMailRenderAbstractFactory.Object
            };

            sut.SendMail(1);

            // --- Assert --
            mockMailRender.Verify(x => x.RenderContent(), Times.Exactly(1));
        }

        [Test]
        [Ignore("Ignore a fixture")]
        public void Test_Intergrating_Mail_Master_Into_System()
        {
            var model = GetSampleData();

            var renderFactory = new SuspiciousStatisticReporRenderAbstractFactory
            {
                SuspiciousStatisticViewModel = model
            };

            var mailMasterRenderAbstractFactory = new MailMasterRenderAbstractFactory
            {
                ReportRenderFactory = renderFactory
            };

            var sut = new SpuMailSender(new FakeMailClient())
            {
                MailMasterRenderAbstractFactory = mailMasterRenderAbstractFactory
            };

            sut.SendMail(1);
        }

        private SuspiciousStatisticViewModel GetSampleData()
        {
            var sut = new SuspiciousStatisticsReportService();

            var list = new List<SuspiciousInfo>
            {
                new SuspiciousInfo
                {
                    CustId = 3293,
                    MatchId = 13760671,
                    WorkflowId = 4,
                    TaskId = 4
                },
                new SuspiciousInfo
                {
                    CustId = 1280,
                    MatchId = 4032122,
                    WorkflowId = 4,
                    TaskId = 4
                },
                new SuspiciousInfo
                {
                    CustId = 1280,
                    MatchId = 12768041,
                    WorkflowId = 4,
                    TaskId = 4
                }
            };

            return sut.GetSuspiciousCustomerStatistics(list);
        }

        private SuspiciousStatisticViewModel GetSampleDataFromArchive()
        {
            var sut = new SuspiciousStatisticsReportService();

            var list = new List<SuspiciousInfo>
            {
                new SuspiciousInfo
                {
                    CustId = 1280,
                    MatchId = 13606626,
                    WorkflowId = 4,
                    TaskId = 4
                },
                new SuspiciousInfo
                {
                    CustId = 1280,
                    MatchId = 13659022,
                    WorkflowId = 4,
                    TaskId = 4
                },
                new SuspiciousInfo
                {
                    CustId = 1280,
                    MatchId = 13675244,
                    WorkflowId = 4,
                    TaskId = 4
                }
            };

            return sut.GetSuspiciousCustomerStatistics(list);
        }
    }
}