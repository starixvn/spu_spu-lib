// --------------------------------------------------------------------------
// <copyright file="SuspiciousCapturedDataInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.10.01">Created</change>
// </history>

namespace FD.Lib.Criteria.DataCapture
{
    using System;
    using Fanex.Data.Repository;

    /// <summary>
    ///     SuspiciousCapturedDataInsertCriteria Class.
    /// </summary>
    public class SuspiciousCapturedDataInsertCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public int DataId { get; set; }

        public int MatchId { get; set; }

        public decimal NewValue { get; set; }

        public decimal OldValue { get; set; }

        public DateTime NewDate { get; set; }

        public DateTime OldDate { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_SuspiciousCapturedDataInsert";
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