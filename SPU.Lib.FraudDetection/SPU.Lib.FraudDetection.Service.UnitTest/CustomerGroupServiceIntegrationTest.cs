namespace FD.Lib.Service.UnitTest
{
    using Core;
    using Criteria.Group;
    using Implement;
    using NUnit.Framework;

    [TestFixture]
    public class CustomerGroupServiceIntegrationTest : IntegrationTest
    {
        [Test]
        [Ignore]
        public void When_Assign_Customer_Group()
        {
            var sut = new CustomerGroupService();

            var result = sut.InsertCustomerGroup(new CustomerGroupInsertCriteria
            {
                CaseId = 1,
                GroupId = 2,
                CustIdList = "1111,2222,3333,4444"
            });

            Assert.IsTrue(result.IsSuccessful);
        }
    }
}