// --------------------------------------------------------------------------
// <copyright file="GroupService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Criteria.Group;
    using DataAccess.Implement;
    using DataAccess.Interface;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     Group Service.
    /// </summary>
    public class GroupService : QueryService, IGroupService
    {
        private readonly IGroupDataAccess _groupDataAccess;

        public GroupService()
        {
            _groupDataAccess = new GroupDataAccess();
        }

        public ICommandResult InsertGroup(ICriteria criteria)
        {
            return _groupDataAccess.InsertGroup(criteria);
        }

        public ICommandResult DeleteGroup(ICriteria criteria)
        {
            return _groupDataAccess.DeleteGroup(criteria);
        }

        public DataCollection GetGroups(ICriteria criteria)
        {
            return _groupDataAccess.GetGroups(criteria);
        }

        public IEnumerable<Group> GetAllGroups(ICriteria criteria)
        {
            return GetData<Group>(criteria);
        }

        public Group GetGroupById(ICriteria criteria)
        {
            var result = GetData<Group>(criteria);

            return result.SingleOrDefault();
        }

        public ICommandResult UpdateGroup(ICriteria criteria)
        {
            return _groupDataAccess.UpdateGroup(criteria);
        }
        
        public IEnumerable<Group> GetGroupsNotInGivenCase(GroupNotInGivenCaseSelectAllCriteria criteria)
        {
            return GetData<Group>(criteria);
        }
    }
}
