// --------------------------------------------------------------------------
// <copyright file="TaskInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Taks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SPU.Lib.FraudDetection.Criteria.Common;

    /// <summary>
    /// TaskInsertCriteria Class.
    /// </summary>
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
