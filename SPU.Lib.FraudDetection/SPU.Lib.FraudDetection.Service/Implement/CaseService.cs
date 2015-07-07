// --------------------------------------------------------------------------
// <copyright file="CaseService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using DataAccess.Implement;
    using DataAccess.Interface;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     Case Service.
    /// </summary>
    public class CaseService : QueryService, ICaseService
    {
        private readonly ICaseDataAccess _caseDataAccess;

        public CaseService()
        {
            _caseDataAccess = new CaseDataAccess();
        }

        public ICommandResult InsertCase(ICriteria criteria)
        {
            return _caseDataAccess.InsertCase(criteria);
        }

        public ICommandResult DeleteCase(ICriteria criteria)
        {
            return _caseDataAccess.DeleteCase(criteria);
        }

        public IEnumerable<CaseInfo> LoadCases(ICriteria criteria)
        {
            return GetData<CaseInfo>(criteria);
        }

        public DataCollection GetCases(ICriteria criteria)
        {
            return _caseDataAccess.GetCases(criteria);
        }

        public IEnumerable<Task> GetTasks(ICriteria criteria)
        {
            return GetData<Task>(criteria);
        }

        public ICommandResult UpdateCase(ICriteria criteria)
        {
            return _caseDataAccess.UpdateCase(criteria);
        }

        public CaseInfo GetCaseById(ICriteria criteria)
        {
            var result = GetData<CaseInfo>(criteria);

            return result.SingleOrDefault();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}