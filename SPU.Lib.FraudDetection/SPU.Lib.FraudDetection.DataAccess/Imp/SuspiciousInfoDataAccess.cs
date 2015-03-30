// --------------------------------------------------------------------------
// <copyright file="SuspiciousInfoDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess
{
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SuspiciousInfoDataAccess : BaseDataAccess
    {
        public ICommandResult InsertSuspiciousCustomer(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public ICommandResult InsertSuspiciousInfo(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}
