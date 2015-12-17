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
    public class CustomerBettingGroup
    {
        public CustomerBettingGroup()
        {
            Customers = new List<Customer>();
        }

        public int GroupId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Currencies
        {
            get
            {
                var distinctCurrencies = Customers.Select(t => t.CurrencyName).Distinct().ToList();
                var currencies = string.Join(",", distinctCurrencies);

                return currencies;
            }
        }

        public List<Customer> Customers { get; set; }
    }
}