// --------------------------------------------------------------------------
// <copyright file="CaseUpdateCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
//   <change who="Aaron.Cao" date="2015.06.22">Updated</change>
// </history>

namespace FD.Lib.Criteria.Case
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     CaseUpdateCriteria Class.
    /// </summary>
    public class CaseUpdateCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public int CaseId { get; set; }

        public string CaseName { get; set; }

        public string CaseDesc { get; set; }

        public bool IsActive { get; set; }

        public bool IsInternal { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_CaseUpdate";
        }

        /// <summary>
        /// Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return CaseId > 0;
        }
    }
}
