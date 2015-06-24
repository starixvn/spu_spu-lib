// --------------------------------------------------------------------------
// <copyright file="ScannedMatchesService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System.Collections.Generic;
    using DataAccess.Implement;
    using DataAccess.Interface;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Interface;

    /// <summary>
    ///     Scanned Matches Service.
    /// </summary>
    public class ScannedMatchesService : QueryService, IScannedMatchesService
    {
        private readonly IScannedMatchesDataAccess _scannedMatchesDataAccess;

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