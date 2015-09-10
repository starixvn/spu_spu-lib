// --------------------------------------------------------------------------
// <copyright file="CurrencyGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.09.10">Created</change>
// </history>

namespace FD.Lib.Criteria.Common
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     The criteria to get all currencies.
    /// </summary>
    public class CurrencyGetAllCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "FD_CurrencyGetAll";
        }
    }
}