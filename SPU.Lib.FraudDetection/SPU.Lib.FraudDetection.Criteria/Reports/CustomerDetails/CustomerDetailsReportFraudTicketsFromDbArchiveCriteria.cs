// --------------------------------------------------------------------------
// <copyright file="CustomerDetailsReportFraudTicketsFromDbArchiveCriteria.cs" company="Nexcel Solutions Vietnam">
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
    /// Customer Detail Report - Fraud Tickets Criteria.
    /// </summary>
    public class CustomerDetailsReportFraudTicketsFromDbArchiveCriteria : CriteriaBase
    {
        public DateTime WinlostDate { get; set; }

        public int MatchId { get; set; }

        public string TransList { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_CustomerDetailsTicketsGetByTransIdsFromDBArchive";
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
