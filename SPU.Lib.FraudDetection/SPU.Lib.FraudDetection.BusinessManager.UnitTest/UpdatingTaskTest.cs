// --------------------------------------------------------------------------
// <copyright file="UpdatingTaskTest.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.12">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest
{
    using System;
    using Moq;
    using NUnit.Framework;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.SendingTasks;

    [TestFixture]
    public class UpdatingTaskTest
    {
        private Mock<IMessageQueue> _mockQueue;
        private ISendingTask _sut;

        [SetUp]
        public void Setup()
        {
            _mockQueue = new Mock<IMessageQueue>();
            _sut = new UpdatingTask(_mockQueue.Object);
        }

        [Test]
        public void When_Updating_Not_Null_Task_Then_Send_Should_Called_Once_()
        {
            //--- Act ---
            var task = new Task();
            var result = _sut.Send(task);

            //--- Assert ---
            _mockQueue.Verify(
                x => x.Send(It.IsAny<Task>(), It.Is<string>(t => t.Equals(_sut.Type.ToString(), StringComparison.OrdinalIgnoreCase))), Times.Exactly(1));
            Assert.IsTrue(result);
        }

        [Test]
        public void Send_Should_Not_Be_Called_Once_When_Updating_Null_Task()
        {
            //--- Act ---
            var result = _sut.Send(null);

            //--- Assert ---
            _mockQueue.Verify(
                x => x.Send(It.IsAny<TaskExecutor>(), It.Is<string>(t => t.Equals(_sut.Type.ToString(), StringComparison.OrdinalIgnoreCase))), Times.Exactly(0));
            Assert.IsFalse(result);
        }
    }
}