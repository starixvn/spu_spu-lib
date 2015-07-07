namespace SPU.Lib.FraudDetection.TaskExecutors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Timers;
    using Core;
    using Core.Utilities;
    using Criteria.SuspiciousInfo;
    using DTO;
    using NextActions;
    using Service.Implement;
    using Service.Interface;

    public class CountingSuspicousTimesTaskExecutor : TaskExecutor
    {
        public CountingSuspicousTimesTaskExecutor(Task task)
            : base(task)
        {
        }

        public CountingSuspicousTimesTaskExecutor(Task task, ITaskService taskService)
            : base(task, taskService)
        {
        }

        public IList<SuspiciousCustomer> SuspiciousCustomers { get; set; }

        public override void Execute()
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
            var ruleQuery = Task.TaskRules.Replace("$param1$", Task.CaseId.ToString());
            SuspiciousCustomers = TaskService.GetSuspiciousCustomers(ruleQuery, Task.TaskId);
        }

        protected override void TakeNextAction()
        {
            if (SuspiciousCustomers.Count == 0)
            {
                return;
            }

            var suspiciousCustomerChunks = SuspiciousCustomers.Chunk(ChunkSize);
            var suspicionList = new List<SuspiciousInfo>();

            foreach (var suspiciousCustomerChunk in suspiciousCustomerChunks)
            {
                var criteria = new SuspiciousHistoryCriteria
                {
                    CustIdList = string.Join(",", suspiciousCustomerChunk.Select(t => t.CustId)),
                    CaseId = Task.CaseId
                };

                suspicionList.AddRange(TaskService.GetSuspiciousCustomerHistory(criteria));
            }

            var nextActionIdList = Task.NextActionIdList.Split(',');
            var nextActionTargetIdList = Task.NextActionTargetIdList.Split(',');

            for (var i = 0; i < nextActionIdList.Count(); i++)
            {
                var actionType = Utility.ParseEnum<NextActionType>(nextActionIdList[i]);
                var nextAction = NextActionFactory.GetNextAction(actionType, int.Parse(nextActionTargetIdList[i]));
                nextAction.SuspicionList = suspicionList;

                nextAction.TakeAction();
            }
        }
    }
}