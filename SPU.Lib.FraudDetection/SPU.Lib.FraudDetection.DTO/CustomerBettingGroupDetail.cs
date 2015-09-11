// --------------------------------------------------------------------------
// <copyright file="CustomerBettingGroup.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.07.08">Created</change>
// </history>

namespace FD.Lib.DTO
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     CustomerBettingGroup Class.
    /// </summary>
    public class CustomerBettingGroupDetail
    {
        public int GroupId { get; set; }

        public int CustId { get; set; }

        public string CustName { get; set; }

        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }
    }
}