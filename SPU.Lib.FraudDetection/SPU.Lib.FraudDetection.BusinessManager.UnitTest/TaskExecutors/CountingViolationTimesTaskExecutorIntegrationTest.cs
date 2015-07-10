namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest.TaskExecutors
{
    using Core;
    using DTO;
    using FraudDetection.TaskExecutors;
    using NUnit.Framework;

    [TestFixture]
    public class CountingViolationTimesTaskExecutorIntegrationTest : IntegrationTest
    {
        [Test]
        [Ignore("Run_Task_Count_Suspicious_Times")]
        public void Run_Task_Count_Suspicious_Times()
        {
            var task = new Task
            {
                EventId = 2,
                Interval = 90,
                IntervalType = "Second",
                CaseId = 2,
                TaskId = 17,
                TaskName = "LongTest_BetCountByMatch_Step2",
                IsActive = true,
                IsBackgroundProcess = true,
                NextActionIdList = "1",
                TaskPreconditions = "select distinct top 10 ups.CustId from bodb02.dbo.match tch with(nolock) , dbo.CustomerGroups ups with(nolock) where tch.sporttype between 1 and 99 and ups.GroupId = 7",
                TaskRules = "select distinct susCust.custid from (select nfo.custid, COUNT(*) as violateCounter from dbo.SuspiciousInfo nfo with(nolock) where nfo.CaseId = 2 group by nfo.CustId)as susCust where susCust.violateCounter >= 3",
                TaskDesc = "LongTest_BetCountByMatch_Step2",
                NextActionTargetIdList = "8"
            };
            // --- Arrange ---
            var sut = TaskExecutorFactory.GetTaskExecutor(task);

            // --- Action ---
            sut.Execute();

            // --- Assert ---
        }
    }
}