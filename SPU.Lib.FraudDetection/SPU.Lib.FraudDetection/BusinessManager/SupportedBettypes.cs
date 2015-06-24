// --------------------------------------------------------------------------
// <copyright file="SupportedBettypes.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager
{
    using System.Collections.Generic;
    using System.Linq;
    using Criteria;
    using DTO;
    using Service.Implement;
    using Service.Interface;

    /// <summary>
    ///     Supported Bet types Class.
    /// </summary>
    public class SupportedBettypes
    {
        private readonly IBettypeService _bettypeService = new BettypeService();
        private List<Bettype> _supportedBettypes = new List<Bettype>();

        public List<Bettype> GetSupportedBettypes()
        {
            if (_supportedBettypes.Count == 0)
            {
                var bettypes = _bettypeService.GetAllSBBettypes(new BettypeSelectAllCriteria());
                _supportedBettypes = bettypes.ToList();
            }

            return _supportedBettypes;
        }

        public bool InsertSupportedBettype(Bettype bettype)
        {
            _supportedBettypes.Add(bettype);

            var criteria = new BettypeInsertCriteria();
            return _bettypeService.InsertBettype(criteria).IsSuccessful;
        }

        public bool DeleteSupportedBettype(Bettype bettype)
        {
            _supportedBettypes.Remove(bettype);

            var criteria = new BettypeDeleteCriteria();
            return _bettypeService.DeleteBettype(criteria).IsSuccessful;
        }
    }
}