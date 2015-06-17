using NUnit.Framework;
using SPU.Lib.FraudDetection.Service.Implement;

namespace SPU.Lib.FraudDetection.MailMasterRenders
{
    [TestFixture]
    public class MailMasterRenderTest
    {
        [Test]
        public void When_Get_Content_Of_Mail_Master_Then_It_Contain_At_Least_One_Paramater()
        {
            var mockMailMasterService = new MailMasterService();

            var sut = new MailMasterRender(mockMailMasterService)
            {
                MailMasterId = 1
            };

            // Act
            var actualContent = sut.GetContent();

            // Assert
            Assert.IsNotEmpty(actualContent);
        }
    }
}