// --------------------------------------------------------------------------
// <copyright file="GroupGetByIdCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.22">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Group
{
    using Fanex.Data.Repository;

    /// <summary>
    /// GroupGetByIdCriteria Class.
    /// </summary>
    public class GroupGetByIdCriteria : CriteriaBase
    {
        public int GroupId { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_GroupGetById";
        }

        /// <summary>
        /// Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return GroupId > 0;
        }
    }
}
