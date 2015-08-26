namespace FD.Lib.Service.UnitTest
{
    using System.Collections.Generic;
    using System.Text;
    using Core;
    using Criteria.Group;
    using Criteria.SuspiciousInfo;
    using DTO;
    using Implement;
    using NUnit.Framework;

    [TestFixture]
    public class SuspiciousCustomerServiceIntegrationTest : IntegrationTest
    {
        [Test]
        [Ignore]
        public void When_Insert_New_Suspicious_Customer_Then_It_Should_Be_Successful()
        {
            var sut = new SuspiciousCustomerService();

            var customers = new List<Customer>()
            {
                new Customer()
                {
                    CustId = 2,
                    CustName = "test"
                }
            };

            var xml = CreateXmlParam(customers);

            var result = sut.InsertSuspiciousCustomer(new SuspiciousCustomerInsertCriteria
            {
                SuspiciousDoc = xml
            });

            Assert.IsTrue(result.IsSuccessful);
        }

        [Test]
        [Ignore]
        public void Get_New_Suspicious_Customers_From_Given_Customers()
        {
            var sut = new SuspiciousCustomerService();
            
            var result = sut.GetNewSuspiciousCustomers(new NewSuspiciousCustomersGetCriteria
            {
                SuspiciousCustomers = "1,2,3,4"
            });

            Assert.IsTrue(result.Count == 2);
        }

        private string CreateXmlParam(IEnumerable<Customer> chunk)
        {
            var builder = new StringBuilder();
            builder.Append("<Root>");

            foreach (var suspiciousInfo in chunk)
            {
                builder.Append("<Row>");
                builder.Append(GetElement("CustId", suspiciousInfo.CustId));
                builder.Append(GetElement("CustName", suspiciousInfo.CustName));
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