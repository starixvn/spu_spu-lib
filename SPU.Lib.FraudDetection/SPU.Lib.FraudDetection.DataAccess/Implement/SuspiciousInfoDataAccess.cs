// --------------------------------------------------------------------------
// <copyright file="SuspiciousInfoDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DataAccess.Implement
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     Suspicious Info Data Access Implement.
    /// </summary>
    public class SuspiciousInfoDataAccess : BaseDataAccess, ISuspiciousInfoDataAccess
    {
        public ICommandResult InsertSuspiciousInfo(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult InsertSuspiciousBetCount(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}