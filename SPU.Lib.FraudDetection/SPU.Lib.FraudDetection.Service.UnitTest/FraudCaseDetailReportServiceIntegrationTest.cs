namespace FD.Lib.Service.UnitTest
{
    using System;
    using Core;
    using Criteria.CaseGroup;
    using Criteria.Reports;
    using Implement;
    using Interface;
    using NUnit.Framework;

    [TestFixture]
    public class FraudCaseDetailReportServiceIntegrationTest : IntegrationTest
    {
        private IFraudCaseDetailReportService sut;
        public override void SetUp()
        {
            base.SetUp();

            sut = new FraudCaseDetailReportService();
        }

        [Test]
        [Ignore]
        public void When_EventDate_Of_Match_Is_Greater_Than_BalanceUp_Date_Then_Get_Data_From_Bob02()
        {
            var result = sut.GetFraudCaseDetails(new FraudCaseDetailReportCriteria
            {
                CaseId = 4,
                MatchId = 14337488,
                EventDate = new DateTime(2015, 8, 5)
            });
        }

        [Test]
        [Ignore]
        public void When_EventDate_Of_Match_Is_Equal_Or_Less_Than_BalanceUp_Date_Then_Get_Data_From_Bodb_Archieve()
        {
            var result = sut.GetFraudCaseDetails(new FraudCaseDetailReportCriteria
            {
                CaseId = 4,
                MatchId = 14310233,
                EventDate = new DateTime(2015, 8, 1)
            });
        }
    }
}