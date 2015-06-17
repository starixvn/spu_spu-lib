using Moq;
using NUnit.Framework;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.MailMasterRenders;
using SPU.Lib.FraudDetection.MailSenders;

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
            mockMailMasterRender.Setup(x => x.RenderContentOfMailMaster()).Returns(new MailMasterInfo()
            {
                MailSubject = "Subjet Test",
                MailContent = "Content Test",
                MailId = 80,
                MailDesc = "Brian is testing"
            });

            sut.SendMail();

            mockMailMasterRender.Verify(x => x.RenderContentOfMailMaster(), Times.Exactly(1));
        }
    }
}