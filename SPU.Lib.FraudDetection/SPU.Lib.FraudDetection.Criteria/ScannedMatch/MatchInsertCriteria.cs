// --------------------------------------------------------------------------
// <copyright file="MatchInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Match
{
    using System;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// MatchInsertCriteria Class.
    /// </summary>
    public class MatchInsertCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public string MatchIdList { get; set; } //// format: "1;2;3".

        public int WorkflowId { get; set; }
             
        public DateTime EventDate { get; set; }
        
        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "SPU_MatchInsert";
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
