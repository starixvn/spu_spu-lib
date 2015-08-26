namespace FD.Lib.Service.UnitTest
{
    using Core;
    using Criteria.Task;
    using Implement;
    using NUnit.Framework;

    [TestFixture]
    public class TaskServiceIntegrationTest : IntegrationTest
    {
        [Test]
        public void When_Insert_New_CaseGroup_Then_Method_InsertCaseGroup_Should_Be_Called()
        {
            var sut = new TaskService();

            var task = sut.GetTaskForExecuting(new TaskGetForExecutingCriteria()
            {
                TaskId = 1
            });
        }
    }
}