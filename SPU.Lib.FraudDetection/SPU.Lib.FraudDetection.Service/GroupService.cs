// --------------------------------------------------------------------------
// <copyright file="GroupService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DataAccess;
    using SPU.Lib.FraudDetection.DTO;

    /// <summary>
    /// Group Service.
    /// </summary>
    public class GroupService : QueryService
    {        
        private GroupDataAccess _groupDataAccess;

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

        public IEnumerable<Group> GetGroups(ICriteria criteria)
        {
            return GetData<Group>(criteria);
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
