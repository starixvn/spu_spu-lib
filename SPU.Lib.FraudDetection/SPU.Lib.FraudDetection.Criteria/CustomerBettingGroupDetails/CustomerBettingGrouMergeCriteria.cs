// --------------------------------------------------------------------------
// <copyright file="CustomerBettingGroupDeleteCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.07.09">Created</change>
// </history>

namespace FD.Lib.Criteria.CustomerBettingGroupDetails
{
    using Fanex.Data.Repository;

    /// <summary>
    /// CustomerBettingGroupDeleteCriteria Class.
    /// </summary>
    public class CustomerBettingGroupsMergeCriteria : CriteriaBase
    {
        public string RelatedGroupIds { get; set; }
        
        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_CustomerBettingGroupsMerge";
        }

        /// <summary>
        /// Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(RelatedGroupIds);
        }
    }
}
