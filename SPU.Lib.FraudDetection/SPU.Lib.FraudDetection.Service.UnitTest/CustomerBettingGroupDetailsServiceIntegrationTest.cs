namespace FD.Lib.Service.UnitTest
{
    using Core;
    using Criteria.CustomerBettingGroup;
    using Criteria.CustomerBettingGroupDetails;
    using Criteria.Group;
    using Fanex.Data.Configuration;
    using Implement;
    using Interface;
    using NUnit.Framework;

    [TestFixture]
    public class CustomerBettingGroupDetailsServiceIntegrationTest : IntegrationTest
    {
        private ICustomerBettingGroupDetailsService _sut;

        public override void SetUp()
        {
            DbSettingProviderManager.Current.Start();
            _sut = new CustomerBettingGroupDetailsService();
        }

        [Test]
        [Ignore]
        public void When_Get_Related_Betting_Group_Then_It_Should_Be_Successful()
        {
            var criteria = new RelatedBettingGroupGetCriteria
            {
                CustIds = "3,5,6"
            };

            var result = _sut.GetRelatedBettingGroups(criteria);

            Assert.IsTrue(result.Count == 2);
        }

        [Test]
        [Ignore]
        public void When_Insert_Customers_Into_Betting_Group_Then_It_Should_Be_Successful()
        {
            var criteria = new CustomersIntoBettingGroupInsertCriteria
            {
                GroupId = 10,
                CustIds = "10,11,12"
            };

            var result = _sut.InsertCustomersIntoBettingGroup(criteria);

            Assert.IsTrue(result.IsSuccessful);
        }

        [Test]
        [Ignore]
        public void When_Merge_Betting_Groups_Then_It_Should_Be_Successful()
        {
            var criteria = new CustomerBettingGroupsMergeCriteria
            {
                RelatedGroupIds = "1,2"
            };

            _sut.MergeCustomerBettingGroups(criteria);
        }
    }
}