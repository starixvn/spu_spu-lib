// --------------------------------------------------------------------------
// <copyright file="ScanMatchTaskExecutor.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace FD.Lib.TaskExecutors
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Utilities;
    using DTO;
    using NextActions;
    using Service.Interface;

    public class ScanMatchTaskExecutor : TaskExecutor
    {
        private readonly List<SuspiciousInfo> _suspicionList;

        private IList<string> _matchIdList;

        public ScanMatchTaskExecutor(Task task)
            : base(task)
        {
            _matchIdList = new List<string>();
            _suspicionList = new List<SuspiciousInfo>();
        }

        public ScanMatchTaskExecutor(Task task, ITaskService taskService)
            : base(task, taskService)
        {
            _matchIdList = new List<string>();
            _suspicionList = new List<SuspiciousInfo>();
        }

        protected override void ClearOldResult()
        {
            _matchIdList.Clear();
            _suspicionList.Clear();
        }

        protected override void ExecutePrecondition()
        {
            var preConditionQuery = Task.TaskPreconditions.Replace("$param1$", Task.TaskId.ToString());
            _matchIdList = TaskService.ExecutePrecondition(preConditionQuery).ToList();
        }

        protected override void ExecuteRule()
        {
            var matchChunks = _matchIdList.Chunk(ChunkSize);

            foreach (var matchChunk in matchChunks)
            {
                var ruleQuery = Task.TaskRules.Replace("$param1$", string.Join(",", matchChunk));
                _suspicionList.AddRange(TaskService.ExecuteRule(ruleQuery, Task.TaskId, Task.CaseId));
            }

            SaveSuspiciousCustomers();
        }

        protected override void TakeNextAction()
        {
            if (_suspicionList.Count == 0)
            {
                return;
            }

            var nextActionIdList = Task.NextActionIdList.Split(',');
            var nextActionTargetIdList = Task.NextActionTargetIdList.Split(',');

            for (var i = 0; i < nextActionIdList.Count(); i++)
            {
                var actionType = Utility.ParseEnum<NextActionType>(nextActionIdList[i]);
                var nextAction = NextActionFactory.GetNextAction(actionType, int.Parse(nextActionTargetIdList[i]), Task.CaseId);
                nextAction.SuspicionList = _suspicionList;

                nextAction.TakeAction();
            }
        }

        private void SaveSuspiciousCustomers()
        {
            var saveAction = new SavingSuspicious(_suspicionList, _matchIdList, Task.TaskId);
            saveAction.TakeAction();
        }
    }
}