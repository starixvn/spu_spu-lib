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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Core.Utilities;
    using DTO;
    using NextActions;
    using Service.Interface;
    using Task = DTO.Task;

    public class ScanMatchTaskExecutor : TaskExecutor
    {
        private readonly List<SuspiciousInfo> _suspicionList;

        private IList<string> _matchIdList;

        private readonly List<Task<IList<SuspiciousInfo>>> _threads;

        public ScanMatchTaskExecutor(Task task)
            : base(task)
        {
            _matchIdList = new List<string>();
            _suspicionList = new List<SuspiciousInfo>();
            _threads = new List<Task<IList<SuspiciousInfo>>>();
        }

        public ScanMatchTaskExecutor(Task task, ITaskService taskService)
            : base(task, taskService)
        {
            _matchIdList = new List<string>();
            _suspicionList = new List<SuspiciousInfo>();
            _threads = new List<Task<IList<SuspiciousInfo>>>();
        }

        protected override void ClearOldResult()
        {
            _threads.Clear();
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
            FindSuspiciousCustomerOnAllMatches();

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

        private void FindSuspiciousCustomerOnAllMatches()
        {
            var coreCount = Environment.ProcessorCount;
            var matchCount = _matchIdList.Count;
            int count = 0;

            for (; count < matchCount; count++)
            {
                if (count >= coreCount)
                {
                    break;
                }

                CreateAndAddNewThread(count);
            }

            int threadsHaveDone = 0;

            while (threadsHaveDone < matchCount)
            {
                int index = System.Threading.Tasks.Task.WaitAny(_threads.ToArray());

                if (_threads[index].Exception == null)
                {
                    _suspicionList.AddRange(_threads[index].Result);
                }

                threadsHaveDone++;
                _threads.RemoveAt(index);

                if (count < matchCount)
                {
                    CreateAndAddNewThread(count);
                    count++;
                }
            }
        }

        private void CreateAndAddNewThread(int count)
        {
            var thread = System.Threading.Tasks.Task.Factory.StartNew((obj) =>
            {
                var id = (string)obj;
                return FindSuspiciousCustomerOnEachMatch(id);
            }, _matchIdList[count]);

            _threads.Add(thread);
        }

        private IList<SuspiciousInfo> FindSuspiciousCustomerOnEachMatch(string matchId)
        {
            var ruleQuery = Task.TaskRules.Replace("$param1$", matchId);
            return TaskService.ExecuteRule(ruleQuery, Task.TaskId, Task.CaseId);
        }

        private void SaveSuspiciousCustomers()
        {
            var saveAction = new SavingSuspicious(_suspicionList, _matchIdList, Task.TaskId);
            saveAction.TakeAction();
        }
    }
}