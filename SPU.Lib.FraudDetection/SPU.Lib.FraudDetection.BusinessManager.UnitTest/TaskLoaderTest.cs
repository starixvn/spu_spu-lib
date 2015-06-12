// --------------------------------------------------------------------------
// <copyright file="TaskLoaderTest.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest
{
    using System.Collections.Generic;
    using Fanex.Data.Configuration;
    using Fanex.NAP.Framework.Data;
    using Moq;
    using NUnit.Framework;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.Service.Implement;
    using SPU.Lib.FraudDetection.Service.Interface;

    public class TaskLoaderTest
    {
        private Mock<ITaskService> _mockTaskService;
        private Mock<IMessageQueue> _mockQueue;
        private ITaskLoader _sut;

        #region Tests For Calling LoadTasks

        [Test]
        public void LoadAllTasks_Should_Be_Called()
        {
            //--- Act ---
            _sut.LoadTasks();

            //--- Assert ---
            _mockTaskService.Verify(x => x.LoadAllTasks(It.IsAny<ICriteria>()), Times.Exactly(1));
        }

        [Test]
        public void Send_Should_Called_Once_When_One_Active_Task()
        {
            //--- Arrange ---
            var sampleTask = GetSampleTask();
            sampleTask.IsActive = true;
            var sampleTasks = new List<TaskInfo> { sampleTask };
            _mockTaskService.Setup(x => x.LoadAllTasks(It.IsAny<ICriteria>())).Returns(sampleTasks);

            //--- Act ---
            _sut.LoadTasks();

            //--- Assert ---
            _mockQueue.Verify(x => x.Send(It.IsAny<object>()), Times.Exactly(1));
        }

        [Test]
        public void Send_Should_Not_Called_Once_When_One_Inactive_Task()
        {
            //--- Arrange ---
            var sampleTask = GetSampleTask();
            sampleTask.IsActive = false;
            var sampleTasks = new List<TaskInfo> { sampleTask };

            _mockTaskService.Setup(x => x.LoadAllTasks(It.IsAny<ICriteria>())).Returns(sampleTasks);

            //--- Act ---
            _sut.LoadTasks();

            //--- Assert ---
            _mockQueue.Verify(x => x.Send(It.IsAny<object>()), Times.Exactly(0));
        }

        #endregion Tests For Calling LoadTasks

        [SetUp]
        public void Setup()
        {
            DbSettingProviderManager.Current.Start();
            _mockTaskService = new Mock<ITaskService>();
            _mockQueue = new Mock<IMessageQueue>();
            _sut = new TaskLoader(_mockTaskService.Object, _mockQueue.Object);
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