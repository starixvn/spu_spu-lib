// --------------------------------------------------------------------------
// <copyright file="CustomerDetailsReportTransListCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.12.14">Created</change>
// </history>

namespace FD.Lib.Criteria.Reports.CustomerDetails
{
    using System;

    /// <summary>
    /// Customer Detail Report - Customer Information Criteria.
    /// </summary>
    public class CustomerDetailsReportTransListCriteria : CustomerDetailsReportCriteria
    {
        public CustomerDetailsReportTransListCriteria(int custId, DateTime fromDate, DateTime toDate)
            : base(custId, fromDate, toDate)
        {
        }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_CustomerDetailsTransListGetByCustId";
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
