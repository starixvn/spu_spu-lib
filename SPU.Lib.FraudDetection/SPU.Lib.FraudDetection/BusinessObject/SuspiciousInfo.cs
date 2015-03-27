// --------------------------------------------------------------------------
// <copyright file="SuspiciousInfo.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessObject
{
    /// <summary>
    /// SuspiciousInfo Class.
    /// </summary>
    public class SuspiciousInfo
    {
        public int CustId { get; set; }

        public int MatchId { get; set; }

        public int WorkflowId { get; set; }

        public string ListTransId { get; set; }
    }
}
