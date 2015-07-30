// --------------------------------------------------------------------------
// <copyright file="GroupListModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.07.30">Created</change>
// </history>

namespace FD.Lib.Model.Group
{
    using System.Collections.Generic;

    /// <summary>
    /// GroupListModel Class.
    /// </summary>
    public class GroupListModel
    {
        public GroupListModel()
        {
            Groups = new List<GroupModel>();
        }

        public int TotalItem { get; set; }

        public IEnumerable<GroupModel> Groups { get; set; } 
    }
}
