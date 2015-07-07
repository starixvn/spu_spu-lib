// --------------------------------------------------------------------------
// <copyright file="TaskSelectAllByWorkflowIdCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Task
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     TaskSelectAllByWorkflowIdCriteria Class.
    /// </summary>
    public class TaskSelectAllByCaseIdCriteria : CriteriaBase
    {
        public int CaseId { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int RowCount { get; set; }

        public TaskSelectAllByCaseIdCriteria()
        {
            PageIndex = 1;
        }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "SPU_TaskSelectAllByCaseId";
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