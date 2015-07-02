namespace SPU.Lib.FraudDetection.TaskExecutors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Timers;
    using Core;
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

        public override void Execute()
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
            var matchChunks = MatchIdList.Chunk(ChunkSize);

            foreach (var matchChunk in matchChunks)
            {
                var ruleQuery = Task.TaskRules.Replace("$param1$", string.Join(",", matchChunk));
                SuspicionList.AddRange(TaskService.ExecuteRule(ruleQuery, Task.TaskId, Task.WorkflowId));
            }

            SaveSuspiciousCustomers();
        }

        private void SaveSuspiciousCustomers()
        {
            var saveAction = new SavingSuspicion(SuspicionList, MatchIdList, Task.TaskId);
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