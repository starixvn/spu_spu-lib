// --------------------------------------------------------------------------
// <copyright file="CustomerDetailsReportMonthlyWinlossCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2016.05.18">Created</change>
// </history>

namespace FD.Lib.Criteria.Reports.CustomerDetails
{
    using System;

    /// <summary>
    /// Customer Detail Report - Monthly Winloss Criteria.
    /// </summary>
    public class CustomerDetailsReportMonthlyWinlossCriteria : CustomerDetailsReportCriteria
    {
        public CustomerDetailsReportMonthlyWinlossCriteria(int custId, DateTime fromDate, DateTime toDate)
            : base(custId, fromDate, toDate)
        {
        }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_CustomerDetailsMonthlyWinlossGet";
        }
    }
}
