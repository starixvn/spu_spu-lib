// --------------------------------------------------------------------------
// <copyright file="IBettypeDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Interface
{
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Bet-type Data Access interface.
    /// </summary>
    public interface IBettypeDataAccess
    {
        /// <summary>
        /// Insert Bet-type.
        /// </summary>
        /// <param name="criteria">Input criteria.</param>
        /// <returns>Command Result.</returns>
        ICommandResult InsertBettype(ICriteria criteria);

        /// <summary>
        /// Delete Bet-type.
        /// </summary>
        /// <param name="criteria">Input criteria.</param>
        /// <returns>Command Result.</returns>
        ICommandResult DeleteBettype(ICriteria criteria);
    }
}
