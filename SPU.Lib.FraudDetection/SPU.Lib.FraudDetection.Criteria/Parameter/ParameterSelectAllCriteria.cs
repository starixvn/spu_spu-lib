// --------------------------------------------------------------------------
// <copyright file="ParameterSelectAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.11">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     ParameterSelectAllCriteria Class.
    /// </summary>
    public class ParameterSelectAllCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "SPU_ParameterSelectAll";
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