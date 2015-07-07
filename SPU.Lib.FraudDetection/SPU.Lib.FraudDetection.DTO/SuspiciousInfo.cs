// --------------------------------------------------------------------------
// <copyright file="SuspiciousInfo.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DTO
{
    /// <summary>
    ///     Suspicious Info Class.
    /// </summary>
    public class SuspiciousInfo
    {
        public int CustId { get; set; }
        public int MatchId { get; set; }
        public int TaskId { get; set; }
        public long TransId { get; set; }
        public int CaseId { get; set; }
    }
}