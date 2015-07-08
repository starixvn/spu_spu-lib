namespace SPU.Lib.FraudDetection.Service.UnitTest
{
    using Core;
    using Criteria.CaseGroup;
    using NUnit.Framework;

    [TestFixture]
    public class CaseGroupServiceIntegrationTest : IntegrationTest
    {
        [Test]
        [Ignore]
        public void When_Select_Existed_CaseGroup_Then_Result_Should_Be_Non_Empty()
        {
            var sut = new CaseGroupService();

            var result = sut.SelectCaseGroup(new CaseGroupSelectCriteria
            {
                CaseId = 1
            });

            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        [Ignore]
        public void When_Select_Non_Existed_CaseGroup_Then_Result_Should_Be_Empty()
        {
            var sut = new CaseGroupService();

            var result = sut.SelectCaseGroup(new CaseGroupSelectCriteria
            {
                CaseId = 99
            });

            Assert.IsTrue(result.Count == 0);
        }
    }
}