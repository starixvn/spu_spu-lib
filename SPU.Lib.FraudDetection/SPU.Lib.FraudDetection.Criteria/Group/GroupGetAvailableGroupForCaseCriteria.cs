// --------------------------------------------------------------------------
// <copyright file="GroupGetAvailableGroupForCaseCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Group
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     GroupGetAvailableGroupForCaseCriteria Class.
    /// </summary>
    public class GroupGetAvailableGroupForCaseCriteria : CriteriaBase
    {
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
            return "FD_GroupGetAvailableGroupForCase";
        }

        /// <summary>
        ///     Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return CaseId > 0;
        }
    }
}
