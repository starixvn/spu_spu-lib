// --------------------------------------------------------------------------
// <copyright file="SuspiciousCustormer.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Model.ReportTemplate
{
    using System;

    public class SuspiciousCustormer
    {
        public string Member { get; set; }

        public string Case { get; set; }

        public string Sport { get; set; }

        public string League { get; set; }

        public int MatchId { get; set; }

        public string MatchCode { get; set; }

        public DateTime EventDate { get; set; }

        public string Event { get; set; }
    }
}