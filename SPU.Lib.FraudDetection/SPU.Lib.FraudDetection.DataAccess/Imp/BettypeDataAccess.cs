// --------------------------------------------------------------------------
// <copyright file="BettypeDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess
{
    using System.Collections.Generic;
    using Fanex.Data;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.Criteria;

    /// <summary>
    /// Bet-type Data Access.
    /// </summary>
    public class BettypeDataAccess
    {
        public BettypeDataAccess() : base()
        {
        }

        public ICommandResult DeleteBettype(ICriteria criteria)
        {
            using (var objectDb = new ObjectDb(criteria.GetSettingKey()))
            {
                var param = criteria.GetSpParams();
                objectDb.ExecuteNonQuery(param);

                return new CommandResult();
            }
        }

        public ICommandResult InsertBettype(ICriteria criteria)
        {
            using (var objectDb = new ObjectDb(criteria.GetSettingKey()))
            {
                var param = criteria.GetSpParams();
                objectDb.ExecuteNonQuery(param);

                return new CommandResult();
            }
        }

        // Get all bet-types should use GetData from QueryService
    }
}
