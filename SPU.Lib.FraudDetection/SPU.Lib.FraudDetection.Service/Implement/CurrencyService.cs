// --------------------------------------------------------------------------
// <copyright file="CurrencyService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Service.Implement
{
    using System.Collections.Generic;
    using DTO;
    using Fanex.Data.Repository;
    using Interface;

    /// <summary>
    ///     Currency Service.
    /// </summary>
    public class CurrencyService : QueryService, ICurrencyService
    {
        public IEnumerable<Currency> GetCurrencies(ICriteria criteria)
        {
            return GetData<Currency>(criteria);
        }
    }
}