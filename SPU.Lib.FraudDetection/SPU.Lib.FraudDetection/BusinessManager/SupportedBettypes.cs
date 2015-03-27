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
    using SPU.Lib.FraudDetection.Criteria;
    using SPU.Lib.FraudDetection.Service;

    /// <summary>
    /// Supported Bet types Class.
    /// </summary>
    public class SupportedBettypes
    {
        private List<Bettype> _supportedBettypes = new List<Bettype>();

        private ConfigurationsService _bettypeService = new ConfigurationsService();    //todo

        public List<Bettype> GetSupportedBettypes()
        {
            if (_supportedBettypes.Count == 0)
            {
                IEnumerable<Bettype> bettypes = _bettypeService.GetData<Bettype>(new BettypeSelectAllCriteria());
                _supportedBettypes = bettypes.ToList();
            }

            return _supportedBettypes;
        }

        public bool InsertSupportedBettypes(Bettype bettype)
        {
            _supportedBettypes.Add(bettype);
            
            BettypeInsertCriteria criteria = new BettypeInsertCriteria();
            //todo
            _bettypeService.Insert(criteria);

            return true;
        }

        public bool RemoveSupportedBettypes(Bettype bettype)
        {
            _supportedBettypes.Remove(bettype);

            BettypeDeleteCriteria criteria = new BettypeDeleteCriteria();
            //todo
            
            return true;
        }
    }
}
