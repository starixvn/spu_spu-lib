// --------------------------------------------------------------------------
// <copyright file="SuspiciousCustomer.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria
{
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// SuspiciousCustomer Class.
    /// </summary>
    public class SuspiciousCustomer : CriteriaBase
    {
        public int CustId { get; set; }

        public string CustName { get; set; }
    }
}
