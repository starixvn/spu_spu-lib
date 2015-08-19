// --------------------------------------------------------------------------
// <copyright file="LeagueGetAllByDateFromDBArchiveCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.08.18">Created</change>
// </history>

namespace FD.Lib.Criteria.Common
{
    using System;
    using Fanex.Data.Repository;

    /// <summary>
    /// League Get All By Date Criteria from BODB ARCHIVE.
    /// </summary>
    public class LeagueGetAllByDateFromDBArchiveCriteria : CriteriaBase
    {
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_LeagueGetAllByDate_DBArchive";
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