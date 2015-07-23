// --------------------------------------------------------------------------
// <copyright file="TaskInfoCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.05.26">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Task
{
    using Fanex.Data.Repository;

    /// <summary>
    /// TaskInfoCriteria Class.
    /// </summary>
    public abstract class TaskInfoCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public string TaskName { get; set; }

        public string TaskDesc { get; set; }

        public string TaskPreconditions { get; set; }

        public string TaskPreconditionsOriginal { get; set; }

        public string TaskPreconditionsFormatted { get; set; }

        public string TaskRules { get; set; }

        public string TaskRulesOriginal { get; set; }

        public string TaskRulesFormatted { get; set; }
        
        public int Interval { get; set; }

        public string IntervalType { get; set; }

        public bool IsActive { get; set; }

        public int EventId { get; set; }

        public string NextActionIdList { get; set; }

        public string NextActionTargetIdList { get; set; }
    }
}