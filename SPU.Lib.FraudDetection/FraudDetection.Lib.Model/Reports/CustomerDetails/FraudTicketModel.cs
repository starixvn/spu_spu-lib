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
        public int HalfTimeHomeScore { get; set; }

        public int HalfTimeAwayScore { get; set; }

        public int FullTimeHomeScore { get; set; }

        public int FullTimeAwayScore { get; set; }
    }
}