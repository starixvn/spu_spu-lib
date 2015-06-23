using System;
using System.Collections.Generic;
using System.Linq;
using SPU.Lib.Core;
using SPU.Lib.FraudDetection.BusinessManager.NextAction;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.Service.Interface;

namespace SPU.Lib.FraudDetection.BusinessManager
{
    public class ScanMatchTaskExecutor : TaskExecutor
    {
        public IList<string> MatchIds { get; set; }

        public List<SuspiciousInfo> SuspiciousInfoList { get; set; }

        public ScanMatchTaskExecutor(Task task) : base(task)
        {
            MatchIds = new List<string>();
            SuspiciousInfoList = new List<SuspiciousInfo>();
        }

        public ScanMatchTaskExecutor(Task task, ITaskService taskService) : base(task, taskService)
        {
        }

        protected override void ExecutePrecondition()
        {
            try
            {
                if (!string.IsNullOrEmpty(Task.TaskPreconditions))
                {
                    var preConditionQuery = Task.TaskPreconditions.Replace("$param1$", Task.WorkflowId.ToString());
                    MatchIds = TaskService.ExecutePrecondition(preConditionQuery).ToList();
                }
            }
            catch (Exception ex)
            {
                Fanex.Logging.Logger.Log.Error("ExecutePrecondition : " + ex);
            }
        }

        protected override void ExecuteRule()
        {
            try
            {
                const int groupSize = 5;
                var matchIdGroups = MatchIds.Chunk(groupSize);

                foreach (IEnumerable<string> group in matchIdGroups)
                {
                    var ruleQuery = Task.TaskRules.Replace("$param1$", string.Join(",", @group));
                    SuspiciousInfoList.AddRange(TaskService.ExecuteRule(ruleQuery, Task.WorkflowId));
                }

                var matchIdList = string.Join(";", MatchIds);
                var saveAction = new SavingSuspicion(SuspiciousInfoList, matchIdList, Task.WorkflowId);
                saveAction.TakeAction();
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
                if (SuspiciousInfoList.Count > 0)
                {
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
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }
    }
}