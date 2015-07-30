// --------------------------------------------------------------------------
// <copyright file="ICaseDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DataAccess.Interface
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Model.Case;

    /// <summary>
    ///     Case Data Access interface.
    /// </summary>
    public interface ICaseDataAccess
    {
        ICommandResult InsertCase(ICriteria criteria);

        ICommandResult UpdateCase(ICriteria criteria);

        ICommandResult DeleteCase(ICriteria criteria);

        CaseListModel GetCases(ICriteria criteria);
    }
}