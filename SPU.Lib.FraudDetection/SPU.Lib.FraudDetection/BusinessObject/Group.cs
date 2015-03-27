// --------------------------------------------------------------------------
// <copyright file="Group.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessObject
{
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Group Class.
    /// </summary>
    public class Group
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public string GroupDesc { get; set; }

        public bool IsActive { get; set; }
    }
}
