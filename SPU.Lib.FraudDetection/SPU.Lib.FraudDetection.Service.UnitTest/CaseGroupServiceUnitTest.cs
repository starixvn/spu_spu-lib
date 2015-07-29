namespace FD.Lib.Service.UnitTest
{
    using Criteria.CaseGroup;
    using DataAccess.Interface;
    using Implement;
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
                GroupIds = "1"
            });

            mockCaseGroupDataAccess.Verify(x => x.InsertCaseGroup(It.IsAny<CaseGroupInsertCriteria>()), Times.Exactly(1));
        }

        [Test]
        public void When_Delete_CaseGroup_Then_Method_DeleteCaseGroup_Should_Be_Called()
        {
            var mockCaseGroupDataAccess = new Mock<ICaseGroupDataAccess>();

            var sut = new CaseGroupService(mockCaseGroupDataAccess.Object);

            sut.DeleteCaseGroup(new CaseGroupDeleteCriteria
            {
                CaseId = 1,
                GroupId = 1
            });

            mockCaseGroupDataAccess.Verify(x => x.DeleteCaseGroup(It.IsAny<CaseGroupDeleteCriteria>()), Times.Exactly(1));
        }
    }
}