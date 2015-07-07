// --------------------------------------------------------------------------
// <copyright file="CaseInfo.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DTO
{
    /// <summary>
    ///     Case information.
    /// </summary>
    public class CaseInfo
    {
        public int CaseId { get; set; }

        public string CaseName { get; set; }

        public string CaseDesc { get; set; }

        public bool IsActive { get; set; }
    }
}