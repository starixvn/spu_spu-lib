// --------------------------------------------------------------------------
// <copyright file="CaseGetByIdCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="" date="">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Case
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     CaseSelectAllCriteria Class.
    /// </summary>
    public class CaseGetByIdCriteria : CriteriaBase
    {
        public int CaseId { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_CaseGetById";
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
