// --------------------------------------------------------------------------
// <copyright file="ParameterGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.11">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Parameter
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     ParameterGetAllCriteria Class.
    /// </summary>
    public class ParameterGetAllCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "FD_ParameterGetAll";
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