using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPU.Lib.FraudDetection.Criteria;

namespace SPU.Lib.FraudDetection.Controller
{
    public class Task
    {
        #region Properties

        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string TaskDesc { get; set; }

        public string TaskPreconditions { get; set; }

        public string TaskRules { get; set; }

        public int WorkflowId { get; set; }

        public bool IsRunMannually { get; set; }

        public int NextActionId { get; set; }

        public int Timer { get; set; } //minutes //todo

        public bool IsActive { get; set; }

        #endregion

        #region Methods

        public bool runTask()
        {
            return true;
        }

        public bool checkPreconditions()
        {
            return true;
        }
        
        public string buildRules()
        {
            return "";
        }

        public List<SuspiciousInfo> getSuspiciousInfo()
        {
            return null;
        }

        public bool takeNextAction(List<SuspiciousInfo> listSuspiciousInfo)
        {
            return true;
        }

        public bool storeDatabase(List<SuspiciousInfo> listSuspiciousInfo)
        {
            return true;
        }

        #endregion

    }
}
