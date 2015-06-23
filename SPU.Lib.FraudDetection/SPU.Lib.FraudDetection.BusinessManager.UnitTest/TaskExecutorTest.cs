using NUnit.Framework;
using SPU.Lib.FraudDetection.DTO;

namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest
{
    [TestFixture]
    public class TaskExecutorTest
    {
        [Test]
        public void When_Then()
        {
            var task = new Task
            {
                EventId = 1,
                Interval = 30,
                IntervalType = "Second",
                WorkflowId = 4,
                TaskId = 5,
                TaskName = "Scan Match - Find Ticket",
                IsActive = true,
                IsBackgroundProcess = true,
                NextActionIdList = "ab"
            };
            // --- Arrange ---
            var sut = TaskExecutorFactory.GetTaskExecutor(task);

            // --- Action ---
            sut.Start();

            // --- Assert ---


        }
    }
}