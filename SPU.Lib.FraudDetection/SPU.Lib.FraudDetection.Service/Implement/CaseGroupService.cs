// --------------------------------------------------------------------------
// <copyright file="CaseGroupService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Service.Implement
{
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.CaseGroup;
    using DataAccess.Interface;
    using DTO;
    using Fanex.NAP.Framework.Command;
    using Interface;

    public class CaseGroupService : QueryService, ICaseGroupService
    {
        private readonly ICaseGroupDataAccess _caseGroupDataAccess;

        public CaseGroupService()
        {
            _caseGroupDataAccess = new CaseGroupDataAccess();
        }

        public CaseGroupService(ICaseGroupDataAccess dataAccess)
        {
            _caseGroupDataAccess = dataAccess;
        }

        public ICommandResult InsertCaseGroup(CaseGroupInsertCriteria criteria)
        {
            return _caseGroupDataAccess.InsertCaseGroup(criteria);
        }

        public ICommandResult DeleteCaseGroup(CaseGroupDeleteCriteria criteria)
        {
            return _caseGroupDataAccess.DeleteCaseGroup(criteria);
        }

        public IList<CaseGroup> GetCaseGroup(CaseGroupGetAllCriteria criteria)
        {
            return GetData<CaseGroup>(criteria).ToList();
        }
    }
}