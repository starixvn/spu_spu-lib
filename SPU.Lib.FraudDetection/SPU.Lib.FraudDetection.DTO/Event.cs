// --------------------------------------------------------------------------
// <copyright file="Event.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DTO
{
    /// <summary>
    ///     Event Class.
    /// </summary>
    public class Event
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public string EventDesc { get; set; }

        public bool IsActive { get; set; }
    }
}