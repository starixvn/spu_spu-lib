// --------------------------------------------------------------------------
// <copyright file="DataCaptureAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.09.29">Created</change>
// </history>

namespace FD.Lib.DataAccess.Implement
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     DataCaptureAccess Implement.
    /// </summary>
    public class DataCaptureAccess : BaseDataAccess, IDataCaptureAccess
    {
        public ICommandResult InsertCapturedData(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult InsertSuspiciousCapturedData(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult UpdateCapturedData(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}