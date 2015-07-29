// --------------------------------------------------------------------------
// <copyright file="CaseGroup.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DTO
{
    public class CaseGroup
    {
        public int CaseId { get; set; }

        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public string GroupDescription { get; set; }
    }
}