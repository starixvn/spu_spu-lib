// --------------------------------------------------------------------------
// <copyright file="GroupDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class GroupDataAccess : BaseDataAccess
    {
        public ICommandResult InsertGroup(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult DeleteGroup(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult UpdateGroup(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult AssignCustToGroup(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}
