// --------------------------------------------------------------------------
// <copyright file="EventService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DataAccess.Implement;
    using SPU.Lib.FraudDetection.DataAccess.Interface;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.Service.Interface;

    /// <summary>
    /// Event Service.
    /// </summary>
    public class EventService : QueryService, IEventService
    {
        private IEventDataAccess _actionDataAccess;

        public EventService()
        {
            _actionDataAccess = new EventDataAccess();
        }

        public IEnumerable<Event> GetEvents(ICriteria criteria)
        {
            return GetData<Event>(criteria);
        }
    }
}
