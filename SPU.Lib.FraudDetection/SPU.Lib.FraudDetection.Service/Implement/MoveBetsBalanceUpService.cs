// --------------------------------------------------------------------------
// <copyright file="MoveBetsBalanceUpService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Service.Implement
{
    using Criteria.SuspiciousStatistic;
    using DTO;
    using Interface;

    public class MoveBetsBalanceUpService : QueryService, IMoveBetsBalanceUpService
    {
        public MoveBetsBalanceUp GetBalanceUpDay(BalanceUpDaySelectCriteria criteria)
        {
            var balanceUpDay = Get<MoveBetsBalanceUp>(criteria);

            return balanceUpDay;
        }
    }
}