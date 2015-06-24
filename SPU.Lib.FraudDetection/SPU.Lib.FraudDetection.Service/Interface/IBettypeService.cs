// --------------------------------------------------------------------------
// <copyright file="IBettypeService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Interface
{
    using System.Collections.Generic;
    using DTO;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    ///     Bet-type Service interface.
    /// </summary>
    public interface IBettypeService
    {
        ICommandResult InsertBettype(ICriteria criteria);
        ICommandResult DeleteBettype(ICriteria criteria);
        IEnumerable<Bettype> GetAllSBBettypes(ICriteria criteria);
        IEnumerable<Sport> GetAllSBSports(ICriteria criteria);
    }
}