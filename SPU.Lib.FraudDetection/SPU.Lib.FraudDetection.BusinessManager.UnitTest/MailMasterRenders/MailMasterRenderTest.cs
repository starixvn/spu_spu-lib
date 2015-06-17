using Fanex.Data.Repository;
using Moq;
using NUnit.Framework;
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
            var mockReportTableRender = new Mock<IReportTemplateRender>();
            var mockPlaceholderReplacer = new PlaceholderReplacer();

            var sut = new MailMasterRender(mockMailMasterService.Object, mockReportTableRender.Object, mockPlaceholderReplacer)
            {
                MailMasterId = 1
            };

            mockMailMasterService.Setup(x => x.GetMailById(It.IsAny<ICriteria>())).Returns(new MailMasterInfo
            {
                MailContent = "It's the content <placeholder>Suspicious Statistics</placeholder>"
            });

            mockReportTableRender.Setup(x => x.RenderContent()).Returns("Placeholder has already replaced.");

            // Act
            var actualContent = sut.RenderContentOfMailMaster();

            // Assert
            Assert.IsFalse(actualContent.MailContent.Contains("{{placeholder}}"));
            Assert.IsTrue(actualContent.MailContent.Contains("Placeholder has already replaced."));
        }
    }
}