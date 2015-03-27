// --------------------------------------------------------------------------
// <copyright file="Bettype.cs" company="Nexcel Solutions Vietnam">
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
    /// Bet type Class.
    /// </summary>
    public class Bettype
    {
        public int BettypeId { get; set; }

        public string BettypeName { get; set; }
    }
}
