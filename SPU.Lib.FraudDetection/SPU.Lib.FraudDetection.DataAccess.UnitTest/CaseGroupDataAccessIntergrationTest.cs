namespace FD.Lib.DataAccess.UnitTest
{
    using Core;
    using Criteria.CaseGroup;
    using Interface;
    using NUnit.Framework;

    [TestFixture]
    public class CaseGroupDataAccessIntergrationTest : IntegrationTest
    {
        [Test]
        [Ignore]
        public void When_Insert_New_CaseGroup_Then_Should_Return_True()
        {
            var dataAccess = new CaseGroupDataAccess();

            var result = dataAccess.InsertCaseGroup(new CaseGroupInsertCriteria
            {
                GroupIds = "3,4,5",
                CaseId = 1
            });

            Assert.IsTrue(result.IsSuccessful);
        }

        [Test]
        [Ignore]
        public void When_Insert_Existed_CaseGroup_Then_Should_Return_False()
        {
            var dataAccess = new CaseGroupDataAccess();

            var result = dataAccess.InsertCaseGroup(new CaseGroupInsertCriteria
            {
                GroupIds = "1",
                CaseId = 1
            });

            Assert.IsFalse(result.IsSuccessful);
        }

        [Test]
        [Ignore]
        public void When_Delete_Existed_CaseGroup_Which_Group_Containing_No_Suspicious_Customer_Then_Should_Return_True()
        {
            var dataAccess = new CaseGroupDataAccess();

            var result = dataAccess.DeleteCaseGroup(new CaseGroupDeleteCriteria
            {
                GroupId = 3,
                CaseId = 3
            });

            Assert.IsTrue(result.IsSuccessful);
        }

        [Test]
        [Ignore]
        public void When_Delete_Existed_CaseGroup_Which_Group_Containing_Suspicious_Customer_Then_Should_Return_False()
        {
            var dataAccess = new CaseGroupDataAccess();

            var result = dataAccess.DeleteCaseGroup(new CaseGroupDeleteCriteria
            {
                GroupId = 2,
                CaseId = 2
            });

            Assert.IsFalse(result.IsSuccessful);
        }
    }
}