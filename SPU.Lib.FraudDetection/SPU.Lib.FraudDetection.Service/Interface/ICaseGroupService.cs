// --------------------------------------------------------------------------
// <copyright file="ICaseGroupService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using System.Collections.Generic;
    using Criteria.CaseGroup;
    using DTO;
    using Fanex.NAP.Framework.Command;

    public interface ICaseGroupService
    {
        ICommandResult InsertCaseGroup(CaseGroupInsertCriteria criteria);

        ICommandResult DeleteCaseGroup(CaseGroupDeleteCriteria criteria);

        IList<CaseGroup> GetCaseGroup(CaseGroupGetAllCriteria criteria);
    }
}