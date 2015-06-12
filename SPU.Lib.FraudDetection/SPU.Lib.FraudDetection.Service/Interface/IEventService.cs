// --------------------------------------------------------------------------
// <copyright file="IEventService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Interface
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DTO;

    /// <summary>
    /// Event Service interface.
    /// </summary>
    public interface IEventService
    {
        IEnumerable<Event> GetEvents(ICriteria criteria);
    }
}
