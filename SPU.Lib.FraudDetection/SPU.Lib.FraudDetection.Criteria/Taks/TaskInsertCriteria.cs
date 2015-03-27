using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fanex.NAP.Framework.Data;

namespace SPU.Lib.FraudDetection.Criteria.Taks
{
    public class TaskInsertCriteria : CriteriaBase
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string TaskDesc { get; set; }

        public string TaskPreconditions { get; set; }

        public string TaskRules { get; set; }

        public int WorkflowId { get; set; }

        public bool IsRunMannually { get; set; }

        public int NextActionId { get; set; }

        public int Timer { get; set; }

        public bool IsActive { get; set; }
    }
}
