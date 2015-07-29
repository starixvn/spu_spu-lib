// --------------------------------------------------------------------------
// <copyright file="MatchInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Criteria.ScannedMatch
{
    using System;
    using Fanex.Data.Repository;

    /// <summary>
    ///     MatchInsertCriteria Class.
    /// </summary>
    public class MatchInsertCriteria : CriteriaBase
    {
        public string MatchIdList { get; set; } //// format: "1,2,3".

        public int TaskId { get; set; }

        public DateTime ScannedDate { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_MatchInsert";
        }

        /// <summary>
        ///     Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}