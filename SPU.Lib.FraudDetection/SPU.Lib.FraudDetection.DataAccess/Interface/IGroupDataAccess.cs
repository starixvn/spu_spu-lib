// --------------------------------------------------------------------------
// <copyright file="IGroupDataAccess.cs" company="Nexcel Solutions Vietnam">
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
    using Model.Group;

    /// <summary>
    ///     Group Data Access Interface.
    /// </summary>
    public interface IGroupDataAccess
    {
        ICommandResult InsertGroup(ICriteria criteria);

        GroupListModel GetGroups(ICriteria criteria);

        ICommandResult UpdateGroup(ICriteria criteria);

        ICommandResult DeleteGroup(ICriteria criteria);

        ICommandResult AssignCustToGroup(ICriteria criteria);
    }
}