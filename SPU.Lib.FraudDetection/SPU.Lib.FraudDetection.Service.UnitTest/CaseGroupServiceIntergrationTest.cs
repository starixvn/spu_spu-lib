namespace SPU.Lib.FraudDetection.Service.UnitTest
{
    using NUnit.Framework;

    [TestFixture]
    public class CaseGroupServiceIntergrationTest
    {
        [Test]
        [Ignore("Ignore a fixture")]
        public void When_Insert_New_CaseGroup_Then_Should_Return_True()
        {
            var sut = new CaseGroupService();

            var result = sut.InsertCaseGroup(new CaseGroupInsertCriteria
            {
                CaseId = 11,
                GroupId = 11
            });

            Assert.IsEmpty(result.Code);
        }

        [Test]
        public void When_Insert_Existed_CaseGroup_Then_Should_Return_False()
        {
            var mockCaseGroupDataAccess = new FakeCaseGroupDataAccess();
            mockCaseGroupDataAccess.CaseGroups.Add(new CaseGroup
            {
                CaseId = 11,
                GroupId = 11
            });

            var sut = new CaseGroupService(mockCaseGroupDataAccess);

            const int expectedErrorCode = 1041;

            var result = sut.InsertCaseGroup(new CaseGroupInsertCriteria
            {
                CaseId = 11,
                GroupId = 11
            });

            Assert.AreEqual(expectedErrorCode, result.Code);
        }

        [Test]
        public void When_Remove_Valid_CaseGroup_Then_ErrorCode_Should_Be_Empty()
        {
            var mockCaseGroupDataAccess = new FakeCaseGroupDataAccess();

            mockCaseGroupDataAccess.CaseGroups.Add(new CaseGroup
            {
                CaseId = 11,
                GroupId = 11
            });

            var sut = new CaseGroupService(mockCaseGroupDataAccess);

            const int expectedErrorCode = 1041;

            var result = sut.InsertCaseGroup(new CaseGroupInsertCriteria
            {
                CaseId = 11,
                GroupId = 11
            });

            Assert.AreEqual(expectedErrorCode, result.Code);
        }
    }
}