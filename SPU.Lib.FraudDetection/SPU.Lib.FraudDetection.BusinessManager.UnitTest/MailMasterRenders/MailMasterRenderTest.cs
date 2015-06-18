using Fanex.Data.Repository;
using Moq;
using NUnit.Framework;
using SPU.Lib.FraudDetection.BusinessManager.UnitTest.ReportTemplateRenders;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.MailMasterRenders;
using SPU.Lib.FraudDetection.ReportTemplateRenders;
using SPU.Lib.FraudDetection.Service.Interface;

namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest.MailMasterRenders
{
    [TestFixture]
    public class MailMasterRenderTest
    {
        [Test]
        public void When_Get_Content_Of_Mail_Master_Then_It_Contain_At_Least_One_Paramater()
        {
            var mockMailMasterService = new Mock<IMailMasterService>();
            var renderAbstractFactory = new Mock<IReportRenderAbstractFactory>();
            var mockPlaceholderReplacer = new PlaceholderReplacer();
            var mockMailTemplateRender = new Mock<IReportTemplateRender>();
            renderAbstractFactory.Setup(x => x.GetReportTemplateRender()).Returns(mockMailTemplateRender.Object);

            var sut = new MailMasterRender(mockMailMasterService.Object, renderAbstractFactory.Object, mockPlaceholderReplacer);

            mockMailMasterService.Setup(x => x.GetMailById(It.IsAny<ICriteria>())).Returns(new MailMasterInfo
            {
                MailContent = "It's the content &lt;placeholder&gt;Suspicious Statistics&lt;/placeholder&gt;"
            });

            mockMailTemplateRender.Setup(x => x.RenderContent()).Returns("Placeholder has already replaced.");

            // Act
            var actualContent = sut.RenderContentOfMailMaster(10);

            // Assert
            Assert.IsFalse(actualContent.MailContent.Contains("&lt;placeholder&gt;"));
            Assert.IsFalse(actualContent.MailContent.Contains("&lt;/placeholder&gt;"));
            Assert.IsTrue(actualContent.MailContent.Contains("Placeholder has already replaced."));
        }
    }
}