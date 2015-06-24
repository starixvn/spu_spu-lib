namespace SPU.Lib.FraudDetection.BusinessManager.UnitTest
{
    using DTO;
    using Fanex.Data.Configuration;
    using NUnit.Framework;

    [TestFixture]
    public class CountingVioliationTimesTaskExecutorTest
    {
        [SetUp]
        public void SetUp()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]
        public void When_Then()
        {
            var task = new Task
            {
                EventId = 2,
                Interval = 30,
                IntervalType = "Second",
                WorkflowId = 4,
                TaskId = 5,
                TaskName = "Count suspicion times by customer",
                IsActive = true,
                IsBackgroundProcess = true,
                NextActionIdList = "1,2",
                TaskRules =
                    "select susCust.custid from (select nfo.custid, COUNT(*) as violateCounter from dbo.SuspiciousInfo nfo with(nolock) where nfo.WorkflowId = $param1$ group by nfo.CustId)as susCust where susCust.violateCounter >= 3",
                TaskDesc = "It's background processing",
                NextActionTargetIdList = "9,10"
            };
            // --- Arrange ---
            var sut = TaskExecutorFactory.GetTaskExecutor(task);

            // --- Action ---
            sut.Execute(null, null);

            while (true)
            {

            }

            // --- Assert ---
        }
    }
}