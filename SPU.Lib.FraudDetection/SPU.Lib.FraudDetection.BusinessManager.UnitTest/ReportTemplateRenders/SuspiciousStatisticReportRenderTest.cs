using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using NUnit.Framework;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.DTO.ReportTemplate;
using SPU.Lib.FraudDetection.ReportTemplateRenders;
using SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders;

namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest.ReportTemplateRenders
{
    [TestFixture]
    public class SuspiciousStatisticReportRenderTest
    {
        private const string MarginTemplateFilePath = TemplateFileManager.MarginTemplateFile;
        private const string SuspiciousTemplateFilePath = TemplateFileManager.SuspiciousStatisticTemplateFile;

        [Test]
        public void When_Include_Two_Table_Renders_Then_Content_Of_Two_Reports_Should_Be_Inserted_Into_The_Report()
        {
            // ---- Arrange ---
            const string contentOfMarginTable = "It's the content of margin table.";
            const string contentOfSuspiciousStatisticTable = "It's the content of suspicious statistic table.";

            var fakeRenderFactory = new FakeSuspiciousStatisticReporRenderAbstractFactory();
            var sut = fakeRenderFactory.GetReportTemplateRender();

            // ---- Act ---

            var actualResult = sut.RenderContent();

            // ---- Assert ---
            Assert.IsTrue(actualResult.Contains(contentOfMarginTable));
            Assert.IsTrue(actualResult.Contains(contentOfSuspiciousStatisticTable));
        }

        [Test]
        public void When_Detecting_Two_Suspicious_Customers_Then_Content_Of_Report_Should_Be_Contain_Them()
        {
            var model = new SuspiciousStatisticViewModel()
            {
                MarginCustormers = GetSampleMarginCustormers(),
                SuspiciousCustormers = GetSampleSuspiciousCustormers()
            };

            var renderFactory = new SuspiciousStatisticReporRenderAbstractFactory
            {
                SuspiciousStatisticViewModel = model,
            };

            var sut = renderFactory.GetReportTemplateRender();

            // ---- Act ---

            var actualResult = sut.RenderContent();

            //// ---- Assert ---
            Assert.IsTrue(actualResult.Contains("member01"));
            Assert.IsTrue(actualResult.Contains("member02"));
            Assert.IsTrue(actualResult.Contains("member03"));
            Assert.IsTrue(actualResult.Contains("member04"));
        }

        #region Manage Sample Data

        private IList<MarginCustormer> GetSampleMarginCustormers()
        {
            var sampleCustomer1 = new MarginCustormer
            {
                Member = "member03",
                Margins = new List<double> {0.98, 1.23, 3.50}
            };

            var sampleCustomer2 = new MarginCustormer
            {
                Member = "member04",
                Margins = new List<double> {1.98, 12.23, 32.50}
            };

            var suspiciousCustomers = new List<MarginCustormer>
            {
                sampleCustomer1,
                sampleCustomer2
            };

            return suspiciousCustomers;
        }

        private List<SuspiciousCustormer> GetSampleSuspiciousCustormers()
        {
            var sampleCustomer1 = new SuspiciousCustormer()
            {
                Member = "member01",
                Workflow = "WF01",
                Sport = "Soccer",
                League = "English Premier League",
                MatchId = 123456,
                MatchCode = "2345",
                EventDate = DateTime.Parse("6/13/2015"),
                Event = "Manchester United vs Chelsea"
            };

            var sampleCustomer2 = new SuspiciousCustormer()
            {
                Member = "member02",
                Workflow = "WF01",
                Sport = "Soccer",
                League = "English Premier League",
                MatchId = 123456,
                MatchCode = "2345",
                EventDate = DateTime.Parse("6/13/2015"),
                Event = "Manchester United vs Chelsea"
            };

            var suspiciousCustomers = new List<SuspiciousCustormer>
            {
                sampleCustomer1,
                sampleCustomer2
            };

            return suspiciousCustomers;
        }

        #endregion
    }
}