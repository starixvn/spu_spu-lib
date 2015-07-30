// --------------------------------------------------------------------------
// <copyright file="GroupModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.07.30">Created</change>
// </history>

namespace FD.Lib.Model.Group
{
    /// <summary>
    /// GroupModel Class.
    /// </summary>
    public class GroupModel
    {
        public int Row { get; set; }

        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public string GroupDesc { get; set; }

        public bool IsActive { get; set; }
    }
}
