// --------------------------------------------------------------------------
// <copyright file="CustomerBettingGroupInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.07.09">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.CustomerBettingGroup
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     CustomerBettingGroupInsertCriteria Class.
    /// </summary>
    public class CustomerBettingGroupInsertCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_CustomerBettingGroupInsert";
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
