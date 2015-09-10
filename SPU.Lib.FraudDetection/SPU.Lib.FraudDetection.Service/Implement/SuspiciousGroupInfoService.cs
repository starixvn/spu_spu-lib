// --------------------------------------------------------------------------
// <copyright file="SuspiciousInfoService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Service.Implement
{
    using Criteria.SuspiciousInfo;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     Suspicious Info Service.
    /// </summary>
    public class SuspiciousGroupInfoService : QueryService, ISuspiciousGroupInfoService
    {
        public ICommandResult InsertSuspiciousGroupInfo(SuspiciousGroupInfoInsertCriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}