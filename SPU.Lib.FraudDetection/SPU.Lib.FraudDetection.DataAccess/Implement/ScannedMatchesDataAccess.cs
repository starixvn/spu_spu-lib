// --------------------------------------------------------------------------
// <copyright file="ScannedMatchesDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DataAccess.Implement
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     Scanned Matches Data Access Implement.
    /// </summary>
    public class ScannedMatchesDataAccess : BaseDataAccess, IScannedMatchesDataAccess
    {
        public ICommandResult InsertScannedMatch(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}