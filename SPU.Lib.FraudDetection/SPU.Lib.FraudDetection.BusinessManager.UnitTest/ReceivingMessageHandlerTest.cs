namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest
{
    using Moq;
    using NUnit.Framework;
    using QueueManagement;

    [TestFixture]
    public class ReceivingMessageHandlerTest
    {
        private Mock<IMessageQueue> _mockQueue;
        private Mock<ITaskManager> _mockTaskManager;
        private IReceivingMessageHandler _sut;

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
    }
}