// --------------------------------------------------------------------------
// <copyright file="DailyDataMonitoring.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DTO
{
    using System;

    public class DailyDataMonitoring
    {
        public int HomeId { get; set; }

        public int AwayId { get; set; }

        public string Event { get; set; }
        
        public DateTime EventDate { get; set; }

        public string DataType { get; set; }

        public DateTime OldDate { get; set; }

        public DateTime NewDate { get; set; }

        public decimal OldValue { get; set; }

        public decimal NewValue { get; set; }
    }
}