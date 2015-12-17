// --------------------------------------------------------------------------
// <copyright file="Customer.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.24">Created</change>
// </history>

namespace FD.Lib.DTO
{
    /// <summary>
    /// The class Customer.
    /// </summary>
    public class Customer
    {
        public int CustId { get; set; }

        public string CustName { get; set; }

        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }
    }
}