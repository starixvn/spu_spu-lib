// --------------------------------------------------------------------------
// <copyright file="WorkflowInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SPU.Lib.FraudDetection.Criteria.Common;

    /// <summary>
    /// WorkflowInsertCriteria Class.
    /// </summary>
    public class WorkflowInsertCriteria : CriteriaBase
    {
        public int WorkflowId { get; set; }

        public string WorkflowName { get; set; }

        public string WorkflowDesc { get; set; }

        public bool IsActive { get; set; }
    }
}
