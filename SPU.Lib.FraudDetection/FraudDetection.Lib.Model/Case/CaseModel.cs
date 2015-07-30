// --------------------------------------------------------------------------
// <copyright file="CaseModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.07.30">Created</change>
// </history>

namespace FD.Lib.Model.Case
{
    /// <summary>
    /// CaseModel Class.
    /// </summary>
    public class CaseModel
    {
        public int Row { get; set; }

        public int CaseId { get; set; }

        public string CaseName { get; set; }

        public string CaseDesc { get; set; }

        public bool IsActive { get; set; }
    }
}
