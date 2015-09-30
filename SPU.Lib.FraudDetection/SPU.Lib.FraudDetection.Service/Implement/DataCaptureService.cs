// --------------------------------------------------------------------------
// <copyright file="DataCaptureService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.09.29">Created</change>
// </history>

namespace FD.Lib.Service.Implement
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using FD.Lib.DataAccess.Implement;
    using FD.Lib.DataAccess.Interface;
    using Interface;

    /// <summary>
    ///     Scanned Matches Service.
    /// </summary>
    public class DataCaptureService : QueryService, IDataCaptureService
    {
        private readonly IDataCaptureServiceAccess _dataCaptureServiceAccess;

        public DataCaptureService()
        {
            _dataCaptureServiceAccess = new DataCaptureServiceAccess();
        }

        public ICommandResult InsertCapturedData(ICriteria criteria)
        {
            return _dataCaptureServiceAccess.InsertCapturedData(criteria);
        }
    }
}