// --------------------------------------------------------------------------
// <copyright file="ICaseService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Service.Interface
{
    using System.Collections.Generic;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Model.Case;

    /// <summary>
    ///     Case Service interface.
    /// </summary>
    public interface ICaseService
    {
        ICommandResult InsertCase(ICriteria criteria);

        ICommandResult DeleteCase(ICriteria criteria);

        IEnumerable<CaseInfo> GetCaseInfo(ICriteria criteria);

        CaseListModel GetCases(ICriteria criteria);

        IEnumerable<Task> GetTasks(ICriteria criteria);

        ICommandResult UpdateCase(ICriteria criteria);

        CaseInfo GetCaseById(ICriteria criteria);

        CaseInfo GetCaseByName(ICriteria criteria);

        void Dispose();
    }
}