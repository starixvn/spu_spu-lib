using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPU.Lib.FraudDetection.Controller
{
    public class Workflow
    {
        #region Properties

        public int WorkflowId { get; set; }

        public string WorkflowName { get; set; }

        public string WorkflowDesc { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Methods

        public bool runWorkflow()
        {
            return true;
        }

        public List<Task> getTasks()
        {
            return null;
        }

        public bool assignTaskToThreadPool(Task task)
        {
            return true;
        }

        #endregion

    }
}
