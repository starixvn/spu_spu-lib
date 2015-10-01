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
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess.Implement;
    using DataAccess.Interface;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     Scanned Matches Service.
    /// </summary>
    public class DataCaptureService : QueryService, IDataCaptureService
    {
        private readonly IDataCaptureAccess _dataCaptureServiceAccess;

        public DataCaptureService()
        {
            _dataCaptureServiceAccess = new DataCaptureAccess();
        }

        public ICommandResult InsertCapturedData(ICriteria criteria)
        {
            return _dataCaptureServiceAccess.InsertCapturedData(criteria);
        }

        public ICommandResult InsertSuspiciousCapturedData(ICriteria criteria)
        {
            return _dataCaptureServiceAccess.InsertSuspiciousCapturedData(criteria);
        }

        public IEnumerable<string> GetAllNotComparedMacthes(ICriteria criteria)
        {
            return GetData<string>(criteria);
        }

        public ICommandResult UpdateCapturedData(ICriteria criteria)
        {
            return _dataCaptureServiceAccess.UpdateCapturedData(criteria);
        }

        public List<DataTypeCapture> GetAllDataTypeCapture(ICriteria criteria)
        {
            return GetData<DataTypeCapture>(criteria).ToList();
        }
    }
}