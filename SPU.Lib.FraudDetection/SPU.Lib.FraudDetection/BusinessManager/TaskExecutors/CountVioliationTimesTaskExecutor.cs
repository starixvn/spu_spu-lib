namespace SPU.Lib.FraudDetection.BusinessManager.TaskExecutors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Timers;
    using Criteria.SuspiciousInfo;
    using DTO;
    using NextAction;
    using Service.Implement;
    using Service.Interface;

    public class CountingVioliationTimesTaskExecutor : TaskExecutor
    {
        public CountingVioliationTimesTaskExecutor(Task task)
            : base(task)
        {
        }

        public CountingVioliationTimesTaskExecutor(Task task, ITaskService taskService)
            : base(task, taskService)
        {
        }

        public IList<SuspiciousCustomer> SuspiciousCustomers { get; set; }

        public override void Execute(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            try
            {
                ExecuteRule();

                TakeNextAction();
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        protected override void ExecuteRule()
        {
            var ruleQuery = Task.TaskRules.Replace("$param1$", Task.WorkflowId.ToString());
            SuspiciousCustomers = TaskService.GetSuspiciousCustomers(ruleQuery, Task.WorkflowId);
        }

        protected override void TakeNextAction()
        {
            if (SuspiciousCustomers.Count == 0)
            {
                return;
            }

            var criteria = new SuspiciousHistoryCriteria
            {
                CustIdList = string.Join(",", SuspiciousCustomers.Select(t => t.CustId)),
                WorkflowId = Task.WorkflowId
            };

            var suspiciousInfoList = TaskService.GetSuspiciousCustomerHistory(criteria);
            var nextActionIdList = Task.NextActionIdList.Split(',');
            var nextActionTargetIdList = Task.NextActionTargetIdList.Split(',');

            for (var i = 0; i < nextActionIdList.Count(); i++)
            {
                var nextAction = ActionFactory.GetAction(
                    short.Parse(nextActionIdList[i]),
                    int.Parse(nextActionTargetIdList[i]),
                    suspiciousInfoList);

                nextAction.TakeAction();
            }
        }
    }
}