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
        [Ignore("Ignore a fixture")]
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

        [Test]
        [Ignore("Ignore a fixture")]
        public void When_Then2()
        {
            var task = new Task
            {
                EventId = 1,
                Interval = 30,
                IntervalType = "Second",
                WorkflowId = 2,
                TaskId = 142,
                TaskName = "Scan Match - Find Ticket",
                IsActive = true,
                IsBackgroundProcess = true,
                NextActionIdList = "2",
                TaskPreconditions =
                    "select top 10 tch.matchid from bodb02.dbo.match tch with(nolock) inner join bodb02.dbo.league gue on tch.leagueid = gue.leagueid inner join bodb02.dbo.sports rts on gue.sporttype = rts.sporttype  where tch.sporttype between 1 and 99 and tch.eventdate < '6/26/2015' AND rts.sporttype = 1 AND tch.eventstatus = 'completed' AND gue.IsMainMarket = gue.IsMainMarket",
                TaskRules =
                    "select ans.custid,ans.matchid,ans.transid from bodb02.dbo.match tch with(nolock) inner join bodb02.dbo.bettrans ans on tch.matchid = ans.matchid inner join bodb02.dbo.odds dds on dds.matchid = ans.matchid and dds.oddsid = ans.oddsid join (SELECT max(ans.transid) transid, max(ans.transdate) deletetime, ans.livehomescore, ans.liveawayscore , ans.matchid FROM bodb02.dbo.bettrans ans with (nolock) WHERE ans.matchid in ($param1$) AND ans.status in ('REJECT') AND ans.liveindicator = 1 GROUP BY ans.livehomescore, ans.liveawayscore, ans.matchid) msc on msc.matchid = ans.matchid where ans.liveindicator = 1 and tch.matchid in ($param1$) and (ans.stake * ans.actualrate >= coalesce(dds.maxbet, 1) * (select p.ParamValue * 0.01 from dbo.Parameters p with(nolock) where p.ParamName = 'PercentageMaxBet') AND ans.transdate BETWEEN DATEADD(ss, -90 , msc.deletetime) AND msc.deletetime AND ans.liveindicator = 1 AND ans.livehomescore = msc.livehomescore AND ans.liveawayscore = msc.liveawayscore AND ans.bettype = 1)",
                TaskDesc = "It's background processing",
                NextActionTargetIdList = "10"
            };
            // --- Arrange ---
            var sut = TaskExecutorFactory.GetTaskExecutor(task);

            // --- Action ---
            sut.Execute(null, null);

            // --- Assert ---
        }
    }
}