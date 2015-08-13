// --------------------------------------------------------------------------
// <copyright file="MatchMonitoring.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DTO
{
    using System.Collections.Generic;

    public class MatchMonitoring
    {
        public int MatchId { get; set; }

        public string LeagueName { get; set; }

        public string MatchCode { get; set; }

        public int HomeId { get; set; }

        public int AwayId { get; set; }

        public string Event { get; set; }

        public string EventStatus { get; set; }

        public Dictionary<string, int> SuspiciousCases;

        public MatchMonitoring()
        {
            SuspiciousCases = new Dictionary<string, int>();
        }
    }
}