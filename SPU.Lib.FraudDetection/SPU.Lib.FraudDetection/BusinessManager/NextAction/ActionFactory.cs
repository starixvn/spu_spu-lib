// --------------------------------------------------------------------------
// <copyright file="ActionFactory.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

using System.Collections.Generic;
using SPU.Lib.FraudDetection.DTO;
namespace SPU.Lib.FraudDetection.BusinessManager
{
    /// <summary>
    /// ActionFactory Class.
    /// </summary>
    public static class ActionFactory
    {        
        /// <summary>
        /// Get an action.
        /// </summary>
        /// <param name="actionId">The actionId.</param>
        /// <returns>Action object.</returns>
        public static BaseAction GetAction(short actionId, int actionTargetId, List<SuspiciousInfo> suspiciousList)
        {
            switch (actionId)
            {
                case 1:
                    return new ActionAssignGroup(suspiciousList, actionTargetId);
                case 2:
                    return new ActionSendEmail(suspiciousList, "thai.tran@nexcel.vn");           
                default:
                    return null;
            }
        }
    }
}
