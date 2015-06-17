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
    using Core;
    using DataAccess.Implement;
    using DataAccess.Interface;
    using Fanex.NAP.Framework.Command;
    using Fanex.Data.Repository;
    using Interface;

    /// <summary>
    /// Group Service.
    /// </summary>
    public class GroupService : QueryService, IGroupService
    {
        private IGroupDataAccess _groupDataAccess;

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

        public ICommandResult UpdateGroup(ICriteria criteria)
        {
            return _groupDataAccess.UpdateGroup(criteria);
        }

        public ICommandResult AssignCustToGroup(ICriteria criteria)
        {
            return _groupDataAccess.AssignCustToGroup(criteria);
        }
    }
}
