// --------------------------------------------------------------------------
// <copyright file="CaseInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
//   <change who="Aaron.Cao" date="2015.07.07">Change to Case</change>
// </history>

namespace FD.Lib.Criteria.Case
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     CaseInsertCriteria Class.
    /// </summary>
    public class CaseInsertCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public string CaseName { get; set; }

        public string CaseDesc { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_CaseInsert";
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