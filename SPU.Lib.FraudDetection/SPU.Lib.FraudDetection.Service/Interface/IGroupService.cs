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
    using System.Collections.Generic;
    using Core;
    using Criteria.Group;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    ///     Group Service interface.
    /// </summary>
    public interface IGroupService
    {
        ICommandResult InsertGroup(ICriteria criteria);

        ICommandResult DeleteGroup(ICriteria criteria);

        DataCollection GetGroups(ICriteria criteria);

        IEnumerable<Group> GetAllGroups(ICriteria criteria);

        Group GetGroupById(ICriteria criteria);

        ICommandResult UpdateGroup(ICriteria criteria);

        IEnumerable<Group> GetGroupsNotInGivenCase(GroupNotInGivenCaseSelectAllCriteria criteria);
        
    }
}
