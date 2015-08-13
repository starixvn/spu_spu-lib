// --------------------------------------------------------------------------
// <copyright file="CaseGetByNameCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.08.13">Created</change>
// </history>

namespace FD.Lib.Criteria.Case
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     CaseSelectAllCriteria Class.
    /// </summary>
    public class CaseGetByNameCriteria : CriteriaBase
    {
        public string CaseName { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_CaseGetByName";
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
