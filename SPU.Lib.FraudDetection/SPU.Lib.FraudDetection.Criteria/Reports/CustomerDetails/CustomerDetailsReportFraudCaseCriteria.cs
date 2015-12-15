// --------------------------------------------------------------------------
// <copyright file="CustomerDetailsReportFraudCaseCriteria.cs" company="Nexcel Solutions Vietnam">
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
    /// Customer Detail Report - Fraud Case Criteria.
    /// </summary>
    public class CustomerDetailsReportFraudCaseCriteria : CustomerDetailsReportCriteria
    {
        public CustomerDetailsReportFraudCaseCriteria(int custId, DateTime fromDate, DateTime toDate)
            : base(custId, fromDate, toDate)
        {
        }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_CustomerDetailsFraudCaseDetailsGet";
        }
    }
}
