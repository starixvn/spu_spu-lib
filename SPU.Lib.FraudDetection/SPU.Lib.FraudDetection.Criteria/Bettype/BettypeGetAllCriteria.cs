// --------------------------------------------------------------------------
// <copyright file="BettypeGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Criteria.Bettype
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     The criteria to get all supporting bet types.
    /// </summary>
    public class BettypeGetAllCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "FD_SBBettypeGetAll";
        }
    }
}