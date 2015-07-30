// --------------------------------------------------------------------------
// <copyright file="GroupDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DataAccess.Implement
{
    using Fanex.Data;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;
    using Model.Group;

    /// <summary>
    ///     Group Data Access Implement.
    /// </summary>
    public class GroupDataAccess : BaseDataAccess, IGroupDataAccess
    {
        public ICommandResult InsertGroup(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public GroupListModel GetGroups(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                var data = db.Query<GroupModel>(criteria.GetSpParams());
                var totalItem = (int)db.GetOuputParams()["rowcount"];
                var result = new GroupListModel
                {
                    TotalItem = totalItem,
                    Groups = data
                };

                return result;
            }
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