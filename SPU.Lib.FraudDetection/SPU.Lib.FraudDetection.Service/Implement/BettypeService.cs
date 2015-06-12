// --------------------------------------------------------------------------
// <copyright file="BettypeService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DataAccess.Implement;
    using SPU.Lib.FraudDetection.DataAccess.Interface;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.Service.Interface;

    /// <summary>
    /// Bet-type Service.
    /// </summary>
    public class BettypeService : QueryService, IBettypeService
    {
        private IBettypeDataAccess _bettypeDataAccess;

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

        public IEnumerable<Bettype> GetAllSBBettypes(ICriteria criteria)
        {
            return GetData<Bettype>(criteria);
        }

        public IEnumerable<Sport> GetAllSBSports(ICriteria criteria)
        {
            return GetData<Sport>(criteria);
        }
    }
}
