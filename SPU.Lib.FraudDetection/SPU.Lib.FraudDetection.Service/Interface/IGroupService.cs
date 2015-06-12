// --------------------------------------------------------------------------
// <copyright file="IGroupService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Interface
{
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.Core;

    /// <summary>
    /// Group Service interface.
    /// </summary>
    public interface IGroupService
    {
        ICommandResult InsertGroup(ICriteria criteria);

        ICommandResult DeleteGroup(ICriteria criteria);

        DataCollection GetGroups(ICriteria criteria);

        ICommandResult UpdateGroup(ICriteria criteria);

        ICommandResult AssignCustToGroup(ICriteria criteria);
    }
}
