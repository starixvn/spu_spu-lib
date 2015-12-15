// --------------------------------------------------------------------------
// <copyright file="WinlossStatisticTopSports.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.12.14">Created</change>
// </history>

namespace FD.Lib.DTO.CustomerDetails
{
    public class WinlossStatisticTopSports
    {
        public string SportName { get; set; }

        public float SumTO { get; set; }

        public float SumWL { get; set; }

        public float Margin { get; set; }
    }
}