namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest.TaskExecutors
{
    using Core;
    using DTO;
    using FraudDetection.TaskExecutors;
    using NUnit.Framework;

    [TestFixture]
    public class ScanMatchTaskExecutorIntegrationTest : IntegrationTest
    {
        [Test]
        [Ignore("Ignore a fixture")]
        public void Run_Task_Scan_Match()
        {
            var task = new Task
            {
                EventId = 1,
                Interval = 60,
                IntervalType = "Second",
                CaseId = 2,
                TaskId = 13,
                TaskName = "Scan Match - Find Ticket",
                IsActive = true,
                IsBackgroundProcess = true,
                NextActionIdList = "1",
                TaskPreconditions =
                    "select distinct top 10 tch.matchid from bodb02.dbo.match tch with(nolock)  where tch.sporttype between 1 and 99 and tch.eventdate < '7/10/2015' AND tch.eventstatus = 'completed'",
                TaskRules =
                    "select distinct ans.custid,ans.matchid,ans.transid from bodb02.dbo.match tch with(nolock) inner join bodb02.dbo.bettrans ans on tch.matchid = ans.matchid inner join (select b.custid, b.matchid, COUNT(distinct b.transid) as ticketscounter from bodb02.dbo.bettrans b with(nolock) where b.matchid in ($param1$) group by b.custid, b.matchid) unt on unt.custid = ans.custid and unt.matchid = ans.matchid where ans.liveindicator = 1 and tch.matchid in ($param1$) and (unt.ticketscounter >= 10)",
                TaskDesc = "It's background processing",
                NextActionTargetIdList = "1"
            };
            // --- Arrange ---
            var sut = TaskExecutorFactory.GetTaskExecutor(task);

            // --- Action ---
            sut.Execute();

            // --- Assert ---
        }
    }
}