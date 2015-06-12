using Fanex.Data.Repository;
using Moq;
using NUnit.Framework;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.Service;

namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest
{
    [TestFixture]
    public class ReceivingMessageHandlerTest
    {
        private IReceivingMessageHandler _sut;

        [SetUp]
        public void SetUp()
        {
            // --- Arrange ---
            var spuQueue = new SpuMessageQueue();
            var mockTaskManager = new Mock<ITaskManager>();
            _sut = new ReceivingMessageHandler(mockTaskManager.Object, spuQueue);
        }

        [Test]
        public void When_Load_One_Active_Task_Then_HandleReceivedMessage_Should_Be_Called()
        {
            var mockTaskLoader = new Mock<ITaskLoader>();

            mockTaskLoader.Setup(x => x.LoadTasks());

            // --- Act ---
            _sut.TriggerReceivingMessage();

            // --- Assert ---
        }

        private TaskInfo GetSampleTask()
        {
            var sampleTask = new TaskInfo
            {
                EventId = 2,
                Interval = 60,
                IntervalType = "Second",
                IsBackgroundProcess = true,
                TaskPreconditions =
                    @"select top 100 tch.matchid from bodb02.dbo.match tch left join dbo.ScannedMatches hes on tch.matchid = hes.matchid  where tch.matchid in (select tch.matchid from bodb02.dbo.match tch with(nolock) where tch.matchid not in (select hes.MatchId from dbo.ScannedMatches hes where hes.WorkflowId = $param1$)) and (tch.eventdate < '6/4/2015' AND tch.eventstatus = 'completed' )",
                TaskRules =
                    "select ans.custid,ans.matchid,ans.transid from bodb02.dbo.match tch inner join bodb02.dbo.bettrans ans on tch.matchid = ans.matchid  where tch.matchid in ($param1$) and (ans.stake >= 300 AND ans.statusid = 112)",
                WorkflowId = 4,
                TaskName = "Scan Match - Find Ticket",
                TaskId = 80
            };

            return sampleTask;
        }
    }
}