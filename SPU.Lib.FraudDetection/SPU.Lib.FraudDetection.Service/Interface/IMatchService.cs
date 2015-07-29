// --------------------------------------------------------------------------
// <copyright file="IMatchService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using System.Collections.Generic;
    using Criteria.SuspiciousStatistic;
    using DTO;

    public interface IMatchService
    {
        IEnumerable<MatchDetail> GetMatchDetails(MatchSelectCriteria criteria);
    }
}