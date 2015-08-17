// --------------------------------------------------------------------------
// <copyright file="LeagueGetAllByDateCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.08.11">Created</change>
// </history>

namespace FD.Lib.Criteria.Common
{
    using System;
    using Fanex.Data.Repository;

    /// <summary>
    /// League Get All By Date Criteria.
    /// </summary>
    public class LeagueGetAllByDateCriteria : CriteriaBase
    {
        public DateTime EventDate { get; set; }

        public bool IsLatestData { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_LeagueGetAllByDate";
        }

        /// <summary>
        /// Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}