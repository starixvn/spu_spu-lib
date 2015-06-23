using System;
using System.Collections.Generic;
using System.Linq;
using SPU.Lib.FraudDetection.BusinessManager.NextAction;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.Service.Implement;
using SPU.Lib.FraudDetection.Service.Interface;

namespace SPU.Lib.FraudDetection.BusinessManager
{
    public class CountSuspicionTimesByCustomerTaskExecutor : TaskExecutor
    {
        
        public IList<SuspiciousCustomer> SuspiciousCustomers { get; set; }

        public CountSuspicionTimesByCustomerTaskExecutor(Task task)
            : base(task)
        {
        }

        public CountSuspicionTimesByCustomerTaskExecutor(Task task, ITaskService taskService)
            : base(task, taskService)
        {
        }

        protected override void ExecutePrecondition()
        {
        }

        protected override void ExecuteRule()
        {
            try
            {
                var ruleQuery = Task.TaskRules.Replace("$param1$", Task.WorkflowId.ToString());
                SuspiciousCustomers = TaskService.GetSuspiciousCustomers(ruleQuery, Task.WorkflowId);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        protected override void TakeNextAction()
        {
            try
            {
                if (SuspiciousCustomers.Count > 0)
                {
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
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }
    }
}