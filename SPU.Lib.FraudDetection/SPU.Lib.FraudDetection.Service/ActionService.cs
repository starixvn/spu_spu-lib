// --------------------------------------------------------------------------
// <copyright file="ActionService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DataAccess;
    using SPU.Lib.FraudDetection.DTO;

    /// <summary>
    /// Workflow Service.
    /// </summary>
    public class ActionService : QueryService
    {
        private ActionDataAccess _actionDataAccess;

        public ActionService()
        {
            _actionDataAccess = new ActionDataAccess();
        }

        public IEnumerable<Action> GetActions(ICriteria criteria)
        {
            return GetData<Action>(criteria);
        }
    }
}
