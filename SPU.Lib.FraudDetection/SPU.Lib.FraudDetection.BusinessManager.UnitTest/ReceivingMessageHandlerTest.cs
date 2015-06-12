using System;
using System.Messaging;
using Moq;
using NUnit.Framework;

namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest
{
    [TestFixture]
    public class ReceivingMessageHandlerTest
    {
        private IReceivingMessageHandler _sut;

        private Mock<IMessageQueue> _mockQueue;
        private Mock<ITaskManager> _mockTaskManager;

        [SetUp]
        public void SetUp()
        {
            // --- Arrange ---
            _mockQueue = new Mock<IMessageQueue>();
            _mockTaskManager = new Mock<ITaskManager>();
            _sut = new ReceivingMessageHandler(_mockTaskManager.Object, _mockQueue.Object);
        }

        [Test]
        public void When_Trigger_Receiving_Message_Then_BeginReceive_Should_Be_Called()
        {
            // --- Act ---
            _sut.TriggerReceivingMessage();

            // --- Assert ---
            _mockQueue.Verify(x => x.BeginReceive(), Times.Exactly(1));
        }

        [Test]
        public void When_Raise_ReceiveCompleted_Then_EndReceive_Should_Be_Called()
        {
            // --- Act ---
            //_mockQueue.Raise(x => x.ReceiveCompleted += null, eventArgs);

            // --- Assert ---
            //_mockQueue.Verify(x => x.EndReceive(It.IsAny<IAsyncResult>()), Times.Exactly(1));
        }
    }
}