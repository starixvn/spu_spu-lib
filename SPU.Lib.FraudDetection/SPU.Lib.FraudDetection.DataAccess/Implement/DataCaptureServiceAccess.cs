// --------------------------------------------------------------------------
// <copyright file="DataCaptureServiceAccess.cs" company="Nexcel Solutions Vietnam">
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
    ///     DataCaptureServiceAccess Implement.
    /// </summary>
    public class DataCaptureServiceAccess : BaseDataAccess, IDataCaptureServiceAccess
    {
        public ICommandResult InsertCapturedData(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}