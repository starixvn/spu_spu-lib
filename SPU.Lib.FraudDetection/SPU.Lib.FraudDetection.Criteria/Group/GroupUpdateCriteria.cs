// --------------------------------------------------------------------------
// <copyright file="GroupUpdateCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
//   <change who="Aaron.Cao" date="2015.06.22">Updated</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Group
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     GroupUpdateCriteria Class.
    /// </summary>
    public class GroupUpdateCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public string GroupDesc { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_GroupUpdate";
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
