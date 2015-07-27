// --------------------------------------------------------------------------
// <copyright file="ConfigGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Config
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     ConfigGetAllCriteria Class.
    /// </summary>
    public class ConfigGetAllCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "FD_ConfigGetAll";
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