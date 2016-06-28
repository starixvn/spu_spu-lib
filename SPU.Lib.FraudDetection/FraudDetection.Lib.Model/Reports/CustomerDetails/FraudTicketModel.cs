// --------------------------------------------------------------------------
// <copyright file="FraudTicketModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.12.25">Created</change>
// </history>

namespace FD.Lib.Model.Reports.CustomerDetails
{
    using System;
    using Fanex.BetList.Core.Entities;

    /// <summary>
    /// Fraud Ticket Model.
    /// </summary>
    [Serializable]
    public class FraudTicketModel : Ticket
    {
        public short? HalfTimeHomeScore { get; set; }

        public short? HalfTimeAwayScore { get; set; }

        public short? FullTimeHomeScore { get; set; }

        public short? FullTimeAwayScore { get; set; }

        public int CaseId { get; set; }

        public string CaseName { get; set; }
    }
}