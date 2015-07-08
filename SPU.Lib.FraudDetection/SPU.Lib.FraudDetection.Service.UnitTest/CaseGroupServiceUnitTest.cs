namespace SPU.Lib.FraudDetection.Service.UnitTest
{
    using DataAccess.Interface;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CaseGroupServiceUnitTest
    {
        [Test]
        public void When_Insert_New_CaseGroup_Then_Method_InsertCaseGroup_Should_Be_Called()
        {
            var mockCaseGroupDataAccess = new Mock<ICaseGroupDataAccess>();

            var sut = new CaseGroupService(mockCaseGroupDataAccess.Object);

            sut.InsertCaseGroup(new CaseGroupInsertCriteria
            {
                CaseId = 1,
                GroupId = 1
            });

            mockCaseGroupDataAccess.Verify(x => x.InsertCaseGroup(It.IsAny<CaseGroupInsertCriteria>()), Times.Exactly(1));
        }
    }
}