// --------------------------------------------------------------------------
// <copyright file="SuspiciousCustomerGetByGroupCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.24">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Reports
{
    using Fanex.Data.Repository;

    /// <summary>
    /// SuspiciousCustomerGetByGroupCriteria Class.
    /// </summary>
    public class SuspiciousCustomerGetByGroupCriteria : CriteriaBase
    {
        public int GroupId { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "SPU_SuspiciousCustomerGetByGroup";
        }

        /// <summary>
        /// Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}
