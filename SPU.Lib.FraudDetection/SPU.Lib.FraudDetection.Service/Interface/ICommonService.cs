// --------------------------------------------------------------------------
// <copyright file="ICommonService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.11.13">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using System.Collections.Generic;
    using DTO;
    using Fanex.Data.Repository;

    /// <summary>
    ///     Common Service interface.
    /// </summary>
    public interface ICommonService
    {
        IEnumerable<Event> GetEvents(ICriteria criteria);

        IEnumerable<Activity> GetActivities(ICriteria criteria);

        IEnumerable<Config> GetConfigsByActivity(ICriteria criteria);

        IEnumerable<CaseType> GetCaseTypes(ICriteria criteria);

        IEnumerable<EvidenceType> GetEvidenceTypes(ICriteria criteria);
    }
}