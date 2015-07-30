// --------------------------------------------------------------------------
// <copyright file="CaseDataAccess.cs" company="Nexcel Solutions Vietnam">
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
    using Model.Case;

    /// <summary>
    ///     Case Data Access Implement.
    /// </summary>
    public class CaseDataAccess : BaseDataAccess, ICaseDataAccess
    {
        public ICommandResult InsertCase(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult UpdateCase(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult DeleteCase(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public CaseListModel GetCases(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                var data = db.Query<CaseModel>(criteria.GetSpParams());
                var totalItem = (int)db.GetOuputParams()["rowcount"];
                var result = new CaseListModel
                {
                    TotalItem = totalItem,
                    Cases = data
                };

                return result;
            }
        }
    }
}