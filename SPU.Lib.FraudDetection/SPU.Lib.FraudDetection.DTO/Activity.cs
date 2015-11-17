// --------------------------------------------------------------------------
// <copyright file="Activity.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.11.12">Created</change>
// </history>

namespace FD.Lib.DTO
{
    /// <summary>
    ///     Activity Class.
    /// </summary>
    public class Activity
    {
        public int ActivityId { get; set; }

        public string ActivityName { get; set; }

        public string ActivityDesc { get; set; }

        public bool IsActive { get; set; }
    }
}