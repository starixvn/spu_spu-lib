// --------------------------------------------------------------------------
// <copyright file="SuspiciousInfoDetails.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.12.14">Created</change>
// </history>

namespace FD.Lib.DTO.CustomerDetails
{
    using System;

    public class SuspiciousInfoDetails
    {
        public int MatchId { get; set; }

        public DateTime EventDate { get; set; }

        public string TransList { get; set; }
    }
}