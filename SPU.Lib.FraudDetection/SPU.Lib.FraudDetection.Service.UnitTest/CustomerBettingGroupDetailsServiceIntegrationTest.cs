namespace FD.Lib.Service.UnitTest
{
    using System.Collections.Generic;
    using System.Text;
    using Core;
    using Criteria.CustomerBettingGroup;
    using Criteria.CustomerBettingGroupDetails;
    using Criteria.Group;
    using DTO;
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
            IEnumerable<SuspiciousGroupInfo> chunk = new List<SuspiciousGroupInfo>
            {
                new SuspiciousGroupInfo
                {
                    CustId = 123,
                    Currency = 20,
                    CurrencyName = "HKH"
                }
            };


            var criteria = new CustomersIntoBettingGroupInsertCriteria
            {
                GroupId = 10,
                XmlDoc = CreateXmlParam(chunk)
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

        private string CreateXmlParam(IEnumerable<SuspiciousGroupInfo> chunk)
        {
            var builder = new StringBuilder();
            builder.Append("<Root>");

            foreach (var suspiciousInfo in chunk)
            {
                builder.Append("<Row>");
                builder.Append(GetElement("CustId", suspiciousInfo.CustId));
                builder.Append(GetElement("Currency", suspiciousInfo.Currency));
                builder.Append(GetElement("CurrencyName", suspiciousInfo.CurrencyName));                
                builder.Append("</Row>");
            }

            builder.Append("</Root>");

            return builder.ToString();
        }

        private string GetElement(string tagName, object value)
        {
            return string.Format("<{0}>{1}</{0}>", tagName, value);
        }
    }
}