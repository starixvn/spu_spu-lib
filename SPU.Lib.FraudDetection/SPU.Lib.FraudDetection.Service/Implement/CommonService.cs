// --------------------------------------------------------------------------
// <copyright file="CommonService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.11.13">Created</change>
// </history>

namespace FD.Lib.Service.Implement
{
    using System.Collections.Generic;
    using DTO;
    using Fanex.Data.Repository;
    using Interface;

    /// <summary>
    ///     Event Service.
    /// </summary>
    public class CommonService : QueryService, ICommonService
    {
        public IEnumerable<Event> GetEvents(ICriteria criteria)
        {
            return GetData<Event>(criteria);
        }

        public IEnumerable<Activity> GetActivities(ICriteria criteria)
        {
            return GetData<Activity>(criteria);
        }

        public IEnumerable<Config> GetConfigsByActivity(ICriteria criteria)
        {
            return GetData<Config>(criteria);
        }

        public IEnumerable<CaseType> GetCaseTypes(ICriteria criteria)
        {
            return GetData<CaseType>(criteria);
        }
    }
}