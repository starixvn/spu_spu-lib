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
        public void When_Select_Existed_CaseGroup_Then_Result_Should_Be_Non_Empty()
        {
            var result = sut.GetFraudCaseDetails(new FraudCaseDetailReportCriteria
            {
                CaseId = 4,
                MatchId = 14337488,
                EventDate = new DateTime(2015, 8, 5)
            });
        }
    }
}