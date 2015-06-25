namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest.TaskExecutors
{
    using DTO;
    using Fanex.Data.Configuration;
    using FraudDetection.TaskExecutors;
    using NUnit.Framework;

    [TestFixture]
    public class ScanMatchTaskExecutorTest
    {
        [SetUp]
        public void SetUp()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]
        public void When_Then()
        {
            var task = new Task
            {
                EventId = 1,
                Interval = 30,
                IntervalType = "Second",
                WorkflowId = 10,
                TaskId = 80,
                TaskName = "Scan Match - Find Ticket",
                IsActive = true,
                IsBackgroundProcess = true,
                NextActionIdList = "1,2",
                TaskPreconditions =
                    "select top 10 tch.matchid from bodb02.dbo.match tch left join dbo.ScannedMatches hes on tch.matchid = hes.matchid where tch.matchid not in (select hes.MatchId from dbo.ScannedMatches hes where hes.TaskId = $param1$) and (tch.eventdate < '6/23/2015' AND tch.eventstatus = 'completed' )",
                TaskRules =
                    "select ans.custid,ans.matchid,ans.transid from bodb02.dbo.match tch inner join bodb02.dbo.bettrans ans on tch.matchid = ans.matchid  where tch.matchid in ($param1$) and (ans.stake >= 300 AND ans.statusid = 112)",
                TaskDesc = "It's background processing",
                NextActionTargetIdList = "9,10"
            };
            // --- Arrange ---
            var sut = TaskExecutorFactory.GetTaskExecutor(task);

            // --- Action ---
            sut.Execute(null, null);
            
            // --- Assert ---
        }
    }
}