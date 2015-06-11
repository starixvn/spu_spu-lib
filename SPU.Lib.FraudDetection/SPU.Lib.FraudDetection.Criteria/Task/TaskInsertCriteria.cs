// --------------------------------------------------------------------------
// <copyright file="TaskInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.05.26">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Task
{
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// TaskInsertCriteria Class.
    /// </summary>
    public class TaskInsertCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public string TaskName { get; set; }

        public string TaskDesc { get; set; }

        public string TaskPreconditions { get; set; }

        public string TaskPreconditionsOriginal { get; set; }

        public string TaskRules { get; set; }

        public string TaskRulesOriginal { get; set; }

        public int WorkflowId { get; set; }

        public int Interval { get; set; }

        public string IntervalType { get; set; }

        public bool IsActive { get; set; }

        public int ActionId { get; set; }

        public string NextActionIdList { get; set; }

        public string NextActionTargetIdList { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "SPU_TaskIns";
        }

        /// <summary>
        /// Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}
