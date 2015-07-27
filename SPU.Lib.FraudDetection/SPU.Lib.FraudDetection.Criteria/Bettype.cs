// --------------------------------------------------------------------------
// <copyright file="BettypeInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     The criteria to insert a supporting bet type.
    /// </summary>
    public class BettypeInsertCriteria : CriteriaBase
    {
        public int BettypeId { get; set; }

        public string BettypeName { get; set; }

        public override string GetSettingKey()
        {
            return string.Empty;
        }
    }
}