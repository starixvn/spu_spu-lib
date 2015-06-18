using System.Collections.Generic;
using Fanex.Data.Configuration;
using NUnit.Framework;
using SPU.Lib.FraudDetection.Criteria;
using SPU.Lib.FraudDetection.Criteria.SuspiciousStatistic;
using SPU.Lib.FraudDetection.DataAccess.Interface;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.Service.Implement;
using SPU.Lib.FraudDetection.Service.Interface;

namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest.SuspiciousStatistic
{
    [TestFixture]
    public class CustomerServiceTest
    {
        [SetUp]
        public void SetUp()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]
        public void TestGetUsernameByCustId()
        {
            var sut = new CustomerService();

            var abao = sut.GetUsernameByCustId(new CustomerSelectCritiria()
            {
                ListCustIds = "1,2,3,4,5,6"
            });

        }

        [Test]
        public void TestSPU_SelectMatchInfoFromDB02()
        {
            var sut = new MatchService();

            var abao = sut.GetMatchDetails(new MatchSelectCriteria()
            {
                ListMatchIds = "9689236,9908275,9908536,11880163",
                IsDbArchieve = true
            });
        }

        [Test]
        public void TestGetSuspiciousCustomerStatistics()
        {
            var sut = new ReportService();

            IList<SuspiciousInfo> list = new List<SuspiciousInfo>()
            {
                new SuspiciousInfo
                {
                    CustId = 1280,
                    MatchId = 13606626
                },
                new SuspiciousInfo
                {
                    CustId = 1280,
                    MatchId = 13659022
                },
                new SuspiciousInfo
                {
                    CustId = 1280,
                    MatchId = 13675244
                },
            };

            var abao = sut.GetSuspiciousCustomerStatistics(list);
        }
    }
}