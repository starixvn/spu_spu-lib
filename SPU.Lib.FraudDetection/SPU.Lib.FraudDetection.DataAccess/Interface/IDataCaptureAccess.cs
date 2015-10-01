// --------------------------------------------------------------------------
// <copyright file="IDataCaptureAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.09.29">Created</change>
// </history>

namespace FD.Lib.DataAccess.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    ///     IDataCaptureAccess interface.
    /// </summary>
    public interface IDataCaptureAccess
    {
        ICommandResult InsertCapturedData(ICriteria criteria);

        ICommandResult InsertSuspiciousCapturedData(ICriteria criteria);

        ICommandResult UpdateCapturedData(ICriteria criteria);
    }
}