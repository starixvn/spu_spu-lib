// --------------------------------------------------------------------------
// <copyright file="ScannedMatchesService.cs" company="Nexcel Solutions Vietnam">
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
    using SPU.Lib.FraudDetection.DataAccess;
    using SPU.Lib.FraudDetection.DTO;

    /// <summary>
    /// Scanned Matches Service.
    /// </summary>
    public class ScannedMatchesService : QueryService
    {
        private ScannedMatchesDataAccess _scannedMatchesDataAccess;

        public ScannedMatchesService()
        {
            _scannedMatchesDataAccess = new ScannedMatchesDataAccess();
        }

        public ICommandResult InsertScannedMatch(ICriteria criteria)
        {
            return _scannedMatchesDataAccess.InsertScannedMatch(criteria);
        }

        public IEnumerable<Match> GetScannedMatches(ICriteria criteria)
        {
            return GetData<Match>(criteria);
        }
    }
}
