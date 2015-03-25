// --------------------------------------------------------------------------
// <copyright file="SupportedBettypes.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Controller
{
    using System.Collections.Generic;
    using SPU.Lib.FraudDetection.Criteria;

    /// <summary>
    /// Supported Bet types Class.
    /// </summary>
    public class SupportedBettypes
    {
        private List<Bettype> _supportedBettypes = new List<Bettype>();

        public bool GetSupportedBettypes()
        {
            return true;
        }

        public bool InsertSupportedBettypes()
        {
            return true;
        }
    }
}
