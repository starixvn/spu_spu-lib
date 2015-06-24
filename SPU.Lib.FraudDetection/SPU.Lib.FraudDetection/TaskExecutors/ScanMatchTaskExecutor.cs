namespace SPU.Lib.FraudDetection.TaskExecutors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Timers;
    using BusinessManager.NextAction;
    using DTO;
    using Service.Interface;

    public class ScanMatchTaskExecutor : TaskExecutor
    {
        public ScanMatchTaskExecutor(Task task)
            : base(task)
        {
            MatchIdList = new List<string>();
            SuspiciousInfoList = new List<SuspiciousInfo>();
        }

        public ScanMatchTaskExecutor(Task task, ITaskService taskService)
            : base(task, taskService)
        {
        }

        public IList<string> MatchIdList { get; set; }
        public List<SuspiciousInfo> SuspiciousInfoList { get; set; }

        public override void Execute(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            try
            {
                ExecutePrecondition();

                ExecuteRule();

                TakeNextAction();
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        protected virtual void ExecutePrecondition()
        {
            var preConditionQuery = Task.TaskPreconditions.Replace("$param1$", Task.WorkflowId.ToString());
            MatchIdList = TaskService.ExecutePrecondition(preConditionQuery).ToList();
        }

        protected override void ExecuteRule()
        {
            var ruleQuery = Task.TaskRules.Replace("$param1$", string.Join(",", MatchIdList));
            SuspiciousInfoList.AddRange(TaskService.ExecuteRule(ruleQuery, Task.WorkflowId));

            SaveSuspicious();
        }

        private void SaveSuspicious()
        {
            var matchIdList = string.Join(";", MatchIdList);
            var saveAction = new SavingSuspicion(SuspiciousInfoList, matchIdList, Task.WorkflowId);
            saveAction.TakeAction();
        }

        protected override void TakeNextAction()
        {
            if (SuspiciousInfoList.Count == 0)
            {
                return;
            }

            var nextActionIdList = Task.NextActionIdList.Split(',');
            var nextActionTargetIdList = Task.NextActionTargetIdList.Split(',');

            for (var i = 0; i < nextActionIdList.Count(); i++)
            {
                var nextAction = ActionFactory.GetAction(
                    short.Parse(nextActionIdList[i]),
                    int.Parse(nextActionTargetIdList[i]),
                    SuspiciousInfoList);
                nextAction.TakeAction();
            }
        }
    }
}