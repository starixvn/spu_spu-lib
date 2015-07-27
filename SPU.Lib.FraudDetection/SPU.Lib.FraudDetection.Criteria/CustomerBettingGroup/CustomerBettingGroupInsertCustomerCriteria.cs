// --------------------------------------------------------------------------
// <copyright file="CustomerBettingGroupInsertCustomerCriteria.cs" company="Nexcel Solutions Vietnam">
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
    ///     CustomerBettingGroupInsertCustomerCriteria Class.
    /// </summary>
    public class CustomerBettingGroupInsertCustomerCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public int GroupId { get; set; }

        public int CustId { get; set; }

        public string CustName { get; set; }

        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_CustomerBettingGroupInsertCustomer";
        }

        /// <summary>
        /// Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return GroupId > 0 && CustId > 0 && CurrencyId > 0;
        }
    }
}
