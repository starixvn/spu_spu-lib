// --------------------------------------------------------------------------
// <copyright file="IScannedMatchesDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Interface
{
    using Fanex.NAP.Framework.Command;
    using Fanex.Data.Repository;

    /// <summary>
    /// Scanned Matches Data Access interface.
    /// </summary>
    public interface IScannedMatchesDataAccess
    {
        ICommandResult InsertScannedMatch(ICriteria criteria);
    }
}
