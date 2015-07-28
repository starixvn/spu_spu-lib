// --------------------------------------------------------------------------
// <copyright file="ICaseService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Interface
{
    using System.Collections.Generic;
    using Core;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    ///     Case Service interface.
    /// </summary>
    public interface ICaseService
    {
        ICommandResult InsertCase(ICriteria criteria);

        ICommandResult DeleteCase(ICriteria criteria);

        IEnumerable<CaseInfo> LoadCases(ICriteria criteria);

        DataCollection GetCases(ICriteria criteria);

        IEnumerable<Task> GetTasks(ICriteria criteria);

        ICommandResult UpdateCase(ICriteria criteria);

        CaseInfo GetCaseById(ICriteria criteria);

        void Dispose();
    }
}