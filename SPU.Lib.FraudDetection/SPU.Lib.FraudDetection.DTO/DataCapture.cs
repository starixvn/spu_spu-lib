// --------------------------------------------------------------------------
// <copyright file="DataCapture.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.09.29">Created</change>
// </history>

namespace FD.Lib.DTO
{
    using System;

    /// <summary>
    ///     Data Capture Class.
    /// </summary>
    public class DataCapture
    {
        public int DataId { get; set; }

        public int MatchId { get; set; }

        public decimal NewValue { get; set; }

        public decimal OldValue { get; set; }

        public DateTime NewDate { get; set; }

        public DateTime OldDate { get; set; }
    }
}