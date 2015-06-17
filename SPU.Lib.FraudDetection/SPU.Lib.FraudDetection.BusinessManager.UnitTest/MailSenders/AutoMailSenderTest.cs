using Fanex.Data.Configuration;
using Moq;
using NUnit.Framework;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.MailMasterRenders;
using SPU.Lib.FraudDetection.MailSenders;
using SPU.Lib.FraudDetection.ReportTemplateRenders;
using SPU.Lib.FraudDetection.Service.Implement;

namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest.MailSenders
{
    [TestFixture]
    public class SpuMailSenderTest
    {
        [Test]
        public void TestSendMail()
        {
            var sut = new SpuMailSender();

            var mockMailMasterRender = new Mock<IMailMasterRender>();

            sut.MailMasterRender = mockMailMasterRender.Object;
            mockMailMasterRender.Setup(x => x.RenderContentOfMailMaster(It.IsAny<int>())).Returns(new MailMasterInfo()
            {
                MailSubject = "Subjet Test",
                MailContent = "Content Test",
                MailId = 80,
                MailDesc = "Brian is testing"
            });

            sut.SendMail(10);

            mockMailMasterRender.Verify(x => x.RenderContentOfMailMaster(It.IsAny<int>()), Times.Exactly(1));
        }

        [Test]
        public void TestSendMail2()
        {
            DbSettingProviderManager.Current.Start();

            var sut = new SpuMailSender();

            var mockReportTemplateRender = new Mock<IReportTemplateRender>();
            var mockMailMasterRender = new MailMasterRender(mockReportTemplateRender.Object);
            
            sut.MailMasterRender = mockMailMasterRender;

            mockReportTemplateRender.Setup(x => x.RenderContent()).Returns("Suspicious Statistic Table and Margin Table");

            sut.SendMail(10);
        }
    }
}