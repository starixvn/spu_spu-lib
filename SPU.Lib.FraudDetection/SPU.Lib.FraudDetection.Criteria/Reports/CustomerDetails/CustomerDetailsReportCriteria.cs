// --------------------------------------------------------------------------
// <copyright file="CustomerDetailsReportCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.12.14">Created</change>
// </history>

namespace FD.Lib.Criteria.Reports.CustomerDetails
{
    using System;
    using Fanex.Data.Repository;

    /// <summary>
    /// Customer Detail Report Criteria.
    /// </summary>
    public class CustomerDetailsReportCriteria : CriteriaBase
    {
        public int CustId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public CustomerDetailsReportCriteria(int custId, DateTime fromDate, DateTime toDate)
        {
            CustId = custId;
            FromDate = fromDate;
            ToDate = toDate;
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
