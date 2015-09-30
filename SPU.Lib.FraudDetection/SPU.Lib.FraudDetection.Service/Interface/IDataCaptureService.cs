// --------------------------------------------------------------------------
// <copyright file="IDataCaptureService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.09.29">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    ///     Data Capture Service interface.
    /// </summary>
    public interface IDataCaptureService
    {
        ICommandResult InsertCapturedData(ICriteria criteria);
    }
}