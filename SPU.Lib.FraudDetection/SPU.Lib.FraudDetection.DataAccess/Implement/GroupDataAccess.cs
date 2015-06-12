// --------------------------------------------------------------------------
// <copyright file="GroupDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Implement
{
    using Core;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using Interface;

    /// <summary>
    /// Group Data Access Implement.
    /// </summary>
    public class GroupDataAccess : BaseDataAccess, IGroupDataAccess
    {
        public ICommandResult InsertGroup(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public DataCollection GetGroups(ICriteria criteria)
        {
            return ReturnDataCollection(criteria);
        }

        public ICommandResult UpdateGroup(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult DeleteGroup(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult AssignCustToGroup(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}
