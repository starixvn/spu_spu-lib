namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest.TaskExecutors
{
    using Core;
    using Criteria.Task;
    using DTO;
    using FraudDetection.TaskExecutors;
    using NUnit.Framework;
    using Service.Implement;

    [TestFixture]
    public class ScanMatchTaskExecutorIntegrationTest : IntegrationTest
    {
        [Test]
        //[Ignore("Ignore a fixture")]
        public void Run_Task_Scan_Match()
        {
            var taskService = new TaskService();

            var task = taskService.GetTaskForExecuting(new TaskSelectForExecutingCriteria()
            {
                TaskId = 1
            });
           
            // --- Arrange ---
            var sut = TaskExecutorFactory.GetTaskExecutor(task);

            // --- Action ---
            sut.Execute();

            // --- Assert ---
        }
    }
}