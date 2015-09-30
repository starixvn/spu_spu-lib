namespace SPU.Lib.FraudDetection.Service.UnitTest
{
    using FD.Lib.Core;
    using FD.Lib.Criteria.Reports;
    using FD.Lib.Service.Implement;
    using NUnit.Framework;

    [TestFixture]
    public class BettingGroupReportServiceIntegrationTest : IntegrationTest
    {
        [Test]
        public void When_Then()
        {
            var sut = new BettingGroupReportService();

            sut.GetAssociationCustomers(new AssociationCustomersGetCriteria
            {
                CustId = 1530119
            });
        }
    }
}