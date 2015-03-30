// --------------------------------------------------------------------------
// <copyright file="ConfigurationsDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DTO
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
