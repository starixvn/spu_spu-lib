using System;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.Service.Interface;

namespace SPU.Lib.FraudDetection.BusinessManager
{
    public class CountSuspicionTimesByCustomerTaskExecutor : TaskExecutor
    {
        public CountSuspicionTimesByCustomerTaskExecutor(Task task) : base(task)
        {
        }

        public CountSuspicionTimesByCustomerTaskExecutor(Task task, ITaskService taskService) : base(task, taskService)
        {
        }

        protected override void ExecutePrecondition()
        {
            throw new NotImplementedException();
        }

        protected override void ExecuteRule()
        {
            throw new NotImplementedException();
        }

        protected override void TakeNextAction()
        {
            throw new NotImplementedException();
        }
    }
}