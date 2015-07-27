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
    /// <summary>
    /// TaskInsertCriteria Class.
    /// </summary>
    public class TaskInsertCriteria : TaskInfoCriteria
    {
        public int CaseId { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_TaskInsert";
        }

        /// <summary>
        ///     Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}