namespace FD.Lib.Service.UnitTest
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Criteria.CaseGroup;
    using Criteria.Reports;
    using Criteria.SuspiciousStatistic;
    using DTO;
    using Implement;
    using Interface;
    using NUnit.Framework;

    [TestFixture]
    public class MatchMonitoringReportServiceIntegrationTest : IntegrationTest
    {
        private IMatchMonitoringReportService sut;

        public override void SetUp()
        {
            base.SetUp();

            sut = new MatchMonitoringReportService();
        }

        [Test]
        [Ignore]
        public void When_EventDate_Of_Match_Is_Greater_Than_BalanceUp_Date_Then_Get_Data_From_Bob02()
        {
            var criteria = new MatchMonitoringReportGetAllCriteria()
            {
                EventDate = new DateTime(2015, 8, 14),
                LeagueId = -1,
                MatchStatus = "All"
               
            };

            var balanceUpMoveBetService = new MoveBetsBalanceUpService();
            var balanceUpMoveBetDates = balanceUpMoveBetService.GetBalanceUpDay(new BalanceUpDaySelectCriteria());

            var matchesInfo = new List<MatchMonitoring>();
            if (criteria.EventDate > balanceUpMoveBetDates.BalanceUpDay)
            {
                criteria.IsLatestData = criteria.EventDate > balanceUpMoveBetDates.MoveBetsDay;
                matchesInfo = sut.GetMatchMonitoringReport(criteria);
            }
            else
            {

            }
        }

    }
}