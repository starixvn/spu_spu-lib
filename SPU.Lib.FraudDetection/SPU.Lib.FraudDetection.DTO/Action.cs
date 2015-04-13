// --------------------------------------------------------------------------
// <copyright file="Action.cs" company="Nexcel Solutions Vietnam">
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
    /// Bet type Class.
    /// </summary>
    public class Action
    {
        public int ActionId { get; set; }

        public string ActionName { get; set; }
    }
}
