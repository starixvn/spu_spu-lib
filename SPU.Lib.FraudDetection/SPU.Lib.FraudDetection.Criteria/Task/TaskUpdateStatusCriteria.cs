// --------------------------------------------------------------------------
// <copyright file="TaskUpdateStatusCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.30">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Task
{
    using Fanex.Data.Repository;

    /// <summary>
    /// TaskUpdateStatusCriteria Class.
    /// </summary>
    public class TaskUpdateStatusCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public int TaskId { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_TaskUpdateStatus";
        }

        /// <summary>
        /// Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return TaskId > 0;
        }
    }
}
