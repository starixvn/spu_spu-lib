// --------------------------------------------------------------------------
// <copyright file="SuspiciousInfo.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DTO
{
    /// <summary>
    ///     Suspicious Group Info Class.
    /// </summary>
    public class SuspiciousGroupInfo
    {
        public int CustId { get; set; }

        public int MatchId { get; set; }

        public int TaskId { get; set; }

        public string TransId { get; set; }

        public int CaseId { get; set; }

        public string GroupingOption { get; set; }

        public int Currency { get; set; }

        public string CurrencyName { get; set; }
    }
}