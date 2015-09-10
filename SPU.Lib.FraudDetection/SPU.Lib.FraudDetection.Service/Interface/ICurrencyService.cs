// --------------------------------------------------------------------------
// <copyright file="ICurrencyService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.09.10">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using System.Collections.Generic;
    using DTO;
    using Fanex.Data.Repository;

    /// <summary>
    ///     Currency Service interface.
    /// </summary>
    public interface ICurrencyService
    {
        IEnumerable<Currency> GetCurrencies(ICriteria criteria);
    }
}