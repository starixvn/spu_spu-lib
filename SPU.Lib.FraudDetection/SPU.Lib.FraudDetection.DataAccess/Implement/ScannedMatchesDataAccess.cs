// --------------------------------------------------------------------------
// <copyright file="ScannedMatchesDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Implement
{
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using Interface;

    /// <summary>
    /// Scanned Matches Data Access Implement.
    /// </summary>
    public class ScannedMatchesDataAccess : BaseDataAccess, IScannedMatchesDataAccess
    {
        public ICommandResult InsertScannedMatch(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}
