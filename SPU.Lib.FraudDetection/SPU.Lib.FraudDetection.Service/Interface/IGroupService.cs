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
    using Core;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using SPU.Lib.FraudDetection.DTO;

    /// <summary>
    ///     Group Service interface.
    /// </summary>
    public interface IGroupService
    {
        ICommandResult InsertGroup(ICriteria criteria);

        ICommandResult DeleteGroup(ICriteria criteria);

        DataCollection GetGroups(ICriteria criteria);

        Group GetGroupById(ICriteria criteria);

        ICommandResult UpdateGroup(ICriteria criteria);
        
        ICommandResult AssignCustomerToGroup(ICriteria criteria);
    }
}
