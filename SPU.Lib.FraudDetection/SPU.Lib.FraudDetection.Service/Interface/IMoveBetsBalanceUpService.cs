// --------------------------------------------------------------------------
// <copyright file="IMoveBetsBalanceUpService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using Criteria.SuspiciousStatistic;
    using DTO;

    public interface IMoveBetsBalanceUpService
    {
        MoveBetsBalanceUp GetBalanceUpDay(BalanceUpDaySelectCriteria criteria);
    }
}