// --------------------------------------------------------------------------
// <copyright file="SuspiciousCustomerTimeGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
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
    /// SuspiciousCustomerTimeGetAllCriteria Class.
    /// </summary>
    public class SuspiciousCustomerTimeGetAllCriteria : CriteriaBase
    {
        public string ListCustIds { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_SuspiciousCustomerGetCount";
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
