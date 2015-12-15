// --------------------------------------------------------------------------
// <copyright file="CustomerDetailsModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.10.29">Created</change>
// </history>

namespace FD.Lib.Model.Reports.CustomerDetails
{
    using System;
    using System.Collections.Generic;
    using DTO.CustomerDetails;
    using FraudCaseDetail;

    /// <summary>
    /// Customer Details Model.
    /// </summary>
    [Serializable]
    public class CustomerDetailsModel
    {
        public CustomerInfo CustInfo { get; set; }

        public IEnumerable<FraudCaseDetails> FraudCasesDetails { get; set; }

        public IEnumerable<LogsNotes> LogsNotesDetails { get; set; }

        public IEnumerable<FraudCaseDetailItem> ViolatedTickets { get; set; }

        public WinlossStatisticSummary Summary { get; set; }

        public IEnumerable<WinlossStatisticEventChoice> EventChoice { get; set; }

        public IEnumerable<WinlossStatisticTopSports> TopSportsByMargin { get; set; }

        public IEnumerable<WinlossStatisticTopBettypes> TopBettypesByMargin { get; set; }

        private string FormatDateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("MM/dd/yyyy hh:mm:ss");
        }
    }
}