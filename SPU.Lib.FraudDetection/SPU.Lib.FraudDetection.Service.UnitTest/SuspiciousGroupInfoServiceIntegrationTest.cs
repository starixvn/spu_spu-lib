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
    public class SuspiciousGroupInfoServiceIntegrationTest : IntegrationTest
    {
        [Test]
        [Ignore]
        public void When_Inserting_Suspicious_Group_Info_Then_It_Should_Be_Successful()
        {
            var sut = new SuspiciousGroupInfoService();

            var suspiciousGroups = new List<SuspiciousGroupInfo>()
            {
                new SuspiciousGroupInfo()
                {
                    MatchId = 123,
                    CustId = 2,
                    CaseId = 1,
                    TaskId = 1,
                    TransId = "123,234,345",
                    GroupingOption = "1.1.1.1"
                }
            };

            var xml = CreateXmlParam(suspiciousGroups);

            var result = sut.InsertSuspiciousGroupInfo(new SuspiciousGroupInfoInsertCriteria
            {
                SuspiciousDoc = xml
            });

            Assert.IsTrue(result.IsSuccessful);
        }

        private string CreateXmlParam(IEnumerable<SuspiciousGroupInfo> chunk)
        {
            var builder = new StringBuilder();
            builder.Append("<Root>");

            foreach (var suspiciousInfo in chunk)
            {
                builder.Append("<Row>");
                builder.Append(GetElement("CustId", suspiciousInfo.CustId));
                builder.Append(GetElement("MatchId", suspiciousInfo.MatchId));
                builder.Append(GetElement("TaskId", suspiciousInfo.TaskId));
                builder.Append(GetElement("TransId", suspiciousInfo.TransId));
                builder.Append(GetElement("CaseId", suspiciousInfo.CaseId));
                builder.Append(GetElement("GroupingOption", suspiciousInfo.GroupingOption));
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