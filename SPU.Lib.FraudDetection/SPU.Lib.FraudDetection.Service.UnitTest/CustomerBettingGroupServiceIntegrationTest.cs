namespace FD.Lib.Service.UnitTest
{
    using Core;
    using Criteria.CustomerBettingGroup;
    using Criteria.Group;
    using Implement;
    using NUnit.Framework;

    [TestFixture]
    public class CustomerBettingGroupServiceIntegrationTest : IntegrationTest
    {
        [Test]
        [Ignore]
        public void When_Creating_Betting_Group_Automatically_Then_It_Should_Be_Successful()
        {
            var sut = new CustomerBettingGroupService();

            var criteria = new BettingGroupAutomaticallyCreateCriteria();

            var result = sut.CreateBettingGroupAutomatically(criteria);

            Assert.IsTrue(result.IsSuccessful);
        }
    }
}