// --------------------------------------------------------------------------
// <copyright file="CaseDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Implement
{
    using Core;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

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

        public DataCollection GetCases(ICriteria criteria)
        {
            return ReturnDataCollection(criteria);
        }
    }
}