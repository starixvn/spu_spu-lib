// --------------------------------------------------------------------------
// <copyright file="ConfigsGetByActivityCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.11.13">Created</change>
// </history>

namespace FD.Lib.Criteria.Config
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     ConfigsGetByActivity Criteria Class.
    /// </summary>
    public class ConfigsGetByActivityCriteria : CriteriaBase
    {
        public int? ActivityId { get; set; }

        public override string GetSettingKey()
        {
            return "FD_ConfigsGetByActivity";
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