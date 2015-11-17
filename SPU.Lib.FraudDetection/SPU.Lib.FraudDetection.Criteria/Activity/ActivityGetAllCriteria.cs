// --------------------------------------------------------------------------
// <copyright file="EventGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.11.13">Created</change>
// </history>

namespace FD.Lib.Criteria.Activity
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     ActivityGetAllCriteria Class.
    /// </summary>
    public class ActivityGetAllCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "FD_ActivityGetAll";
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