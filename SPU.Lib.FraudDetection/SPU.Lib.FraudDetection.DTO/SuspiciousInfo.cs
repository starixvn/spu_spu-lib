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
    using System;

    /// <summary>
    ///     Suspicious Info Class.
    /// </summary>
    public class SuspiciousInfo
    {
        public int CustId { get; set; }

        public string CustName { get; set; }

        public int MatchId { get; set; }

        public DateTime EventDate { get; set; }

        public int TaskId { get; set; }

        public string TransId { get; set; }

        public int CaseId { get; set; }

        public int ViolationCounter { get; set; }
    }
}