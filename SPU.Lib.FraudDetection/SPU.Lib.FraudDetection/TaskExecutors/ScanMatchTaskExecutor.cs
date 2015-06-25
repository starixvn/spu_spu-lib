namespace SPU.Lib.FraudDetection.TaskExecutors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Timers;
    using Core.Utilities;
    using DTO;
    using NextActions;
    using Service.Interface;

    public class ScanMatchTaskExecutor : TaskExecutor
    {
        public ScanMatchTaskExecutor(Task task)
            : base(task)
        {
            MatchIdList = new List<string>();
            SuspicionList = new List<SuspiciousInfo>();
        }

        public ScanMatchTaskExecutor(Task task, ITaskService taskService)
            : base(task, taskService)
        {
        }

        public IList<string> MatchIdList { get; set; }
        public List<SuspiciousInfo> SuspicionList { get; set; }

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
            var preConditionQuery = Task.TaskPreconditions.Replace("$param1$", Task.TaskId.ToString());
            MatchIdList = TaskService.ExecutePrecondition(preConditionQuery).ToList();
        }

        protected override void ExecuteRule()
        {
            var ruleQuery = Task.TaskRules.Replace("$param1$", string.Join(",", MatchIdList));
            SuspicionList.AddRange(TaskService.ExecuteRule(ruleQuery, Task.TaskId, Task.WorkflowId));

            SaveSuspicious();
        }

        private void SaveSuspicious()
        {
            var matchIdList = string.Join(",", MatchIdList);
            var saveAction = new SavingSuspicion(SuspicionList, matchIdList, Task.WorkflowId);
            saveAction.TakeAction();
        }

        protected override void TakeNextAction()
        {
            if (SuspicionList.Count == 0)
            {
                return;
            }

            var nextActionIdList = Task.NextActionIdList.Split(',');
            var nextActionTargetIdList = Task.NextActionTargetIdList.Split(',');

            for (var i = 0; i < nextActionIdList.Count(); i++)
            {
                var actionType = Utility.ParseEnum<NextActionType>(nextActionIdList[i]);
                var nextAction = NextActionFactory.GetNextAction(actionType, int.Parse(nextActionTargetIdList[i]));
                nextAction.SuspicionList = SuspicionList;

                nextAction.TakeAction();
            }
        }
    }
}