// --------------------------------------------------------------------------
// <copyright file="IScannedMatchesService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Interface
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DTO;

    /// <summary>
    /// Scanned Matches Service interface.
    /// </summary>
    public interface IScannedMatchesService
    {
        ICommandResult InsertScannedMatch(ICriteria criteria);

        IEnumerable<Match> GetScannedMatches(ICriteria criteria);
    }
}
