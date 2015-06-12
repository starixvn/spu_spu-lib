// --------------------------------------------------------------------------
// <copyright file="ScannedMatches.cs" company="Nexcel Solutions Vietnam">
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
    using Fanex.NAP.Framework.Command;
    using SPU.Lib.FraudDetection.Criteria.Match;
    using SPU.Lib.FraudDetection.DTO;
    using SPU.Lib.FraudDetection.Service.Implement;
    using SPU.Lib.FraudDetection.Service.Interface;    

    /// <summary>
    /// Scanned Matches Class.
    /// </summary>
    public class ScannedMatches
    {
        private List<Match> _scannedMatches = new List<Match>();

        private IScannedMatchesService _scannedMatchService = new ScannedMatchesService();

        /// <summary>
        /// Get configuration list.
        /// </summary>
        /// <returns>The list of configurations.</returns>
        public List<Match> GetScannedMatches()
        {
            if (_scannedMatches.Count == 0)
            {
                IEnumerable<Match> matches = _scannedMatchService.GetScannedMatches(new MatchSelectAllCriteria());
                _scannedMatches = matches.ToList();
            }

            return _scannedMatches;
        }

        public ICommandResult InsertMatch(Match match)
        {
            _scannedMatches.Add(match);

            MatchInsertCriteria criteria = new MatchInsertCriteria();

            return _scannedMatchService.InsertScannedMatch(criteria);
        }            
    }
}
