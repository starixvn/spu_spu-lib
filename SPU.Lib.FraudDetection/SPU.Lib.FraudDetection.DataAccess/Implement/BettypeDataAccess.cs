// --------------------------------------------------------------------------
// <copyright file="BettypeDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Implement
{
    using Fanex.NAP.Framework.Command;
    using Fanex.Data.Repository;
    using Interface;

    /// <summary>
    /// Bet-type Data Access Implement.
    /// </summary>
    public class BettypeDataAccess : BaseDataAccess, IBettypeDataAccess
    {
        /// <summary>
        /// Insert Bet-type.
        /// </summary>
        /// <param name="criteria">Input criteria.</param>
        /// <returns>Command Result.</returns>
        public ICommandResult InsertBettype(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        /// <summary>
        /// Delete Bet-type.
        /// </summary>
        /// <param name="criteria">Input criteria.</param>
        /// <returns>Command Result.</returns>
        public ICommandResult DeleteBettype(ICriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }
    }
}
