// --------------------------------------------------------------------------
// <copyright file="ActionFactory.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>


namespace SPU.Lib.FraudDetection.BusinessManager.NextAction
{
    using System.Collections.Generic;
    using SPU.Lib.FraudDetection.DTO;

    /// <summary>
    /// ActionFactory Class.
    /// </summary>
    public static class ActionFactory
    {
        /// <summary>
        /// Get An Action.
        /// </summary>
        /// <param name="actionId">Action ID.</param>
        /// <param name="actionTargetId">Action Target ID.</param>
        /// <param name="suspiciousList">Suspicious List.</param>
        /// <returns>Base Action.</returns>
        public static BaseAction GetAction(short actionId, int actionTargetId, List<SuspiciousInfo> suspiciousList)
        {
            switch (actionId)
            {
                case 1:
                    return new ActionAssignGroup(suspiciousList, actionTargetId);

                case 2:
                    return new ActionSendEmail(suspiciousList, "long.luu@nexcel.vn");           

                default:
                    return null;
            }
        }
    }
}