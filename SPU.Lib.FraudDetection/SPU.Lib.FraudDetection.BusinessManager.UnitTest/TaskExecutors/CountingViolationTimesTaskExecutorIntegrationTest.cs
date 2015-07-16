namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest.TaskExecutors
{
    using Core;
    using Criteria.Task;
    using DTO;
    using FraudDetection.TaskExecutors;
    using NUnit.Framework;
    using Service.Implement;

    [TestFixture]
    public class CountingViolationTimesTaskExecutorIntegrationTest : IntegrationTest
    {
        [Test]
        //[Ignore("Run_Task_Count_Suspicious_Times")]
        public void Run_Task_Count_Suspicious_Times()
        {
            var taskService = new TaskService();
            var task = taskService.GetTaskForExecuting(new TaskSelectForExecutingCriteria()
            {
                TaskId = 2
            });

            // --- Arrange ---
            var sut = TaskExecutorFactory.GetTaskExecutor(task);

            // --- Action ---
            sut.Execute();

            // --- Assert ---
        }
    }
}