// --------------------------------------------------------------------------
// <copyright file="TaskGetAllByCaseIdCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Criteria.Task
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     TaskGetAllByCaseIdCriteria Class.
    /// </summary>
    public class TaskGetAllByCaseIdCriteria : CriteriaBase
    {
        public TaskGetAllByCaseIdCriteria()
        {
            PageIndex = 1;
        }

        public int CaseId { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int PageCount { get; set; }

        public int RowCount { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_TaskGetAllByCaseId";
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