// --------------------------------------------------------------------------
// <copyright file="BettypeService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.Criteria;
    using SPU.Lib.FraudDetection.DataAccess;

    /// <summary>
    /// Bet-type Service.
    /// </summary>
    public class BettypeService : QueryService
    {
        private BettypeDataAccess _bettypeDataAccess;

        public BettypeService()
        {
            _bettypeDataAccess = new BettypeDataAccess();
        }

        public ICommandResult InsertBettype(ICriteria criteria)
        {
            return _bettypeDataAccess.InsertBettype(criteria);
        }

        public ICommandResult DeleteBettype(ICriteria criteria)
        {
            return _bettypeDataAccess.DeleteBettype(criteria);
        }

        public IEnumerable<Bettype> GetAllBettypes(ICriteria criteria)
        {
            return GetData<Bettype>(criteria);
        }
    }
}
