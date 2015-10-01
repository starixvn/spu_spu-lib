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
    using System.Collections.Generic;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    ///     Data Capture Service interface.
    /// </summary>
    public interface IDataCaptureService
    {
        ICommandResult InsertCapturedData(ICriteria criteria);

        ICommandResult InsertSuspiciousCapturedData(ICriteria criteria);

        IEnumerable<string> GetAllNotComparedMacthes(ICriteria criteria);

        ICommandResult UpdateCapturedData(ICriteria criteria);

        List<DataTypeCapture> GetAllDataTypeCapture(ICriteria criteria);
    }
}