// --------------------------------------------------------------------------
// <copyright file="ISuspiciousInfoDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DataAccess.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    ///     Suspicious Info Data Access interface.
    /// </summary>
    public interface ISuspiciousInfoDataAccess
    {
        ICommandResult InsertSuspiciousInfo(ICriteria criteria);
    }
}