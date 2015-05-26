// --------------------------------------------------------------------------
// <copyright file="SuspiciousInfoInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria
{
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// SuspiciousInfo Class.
    /// </summary>
    public class SuspiciousInfoInsertCriteria : CriteriaBase
    {        
        public string CustIdList { get; set; }  //// format: "1;2;3".
        
        public string MatchIdList { get; set; } //// format: "1;2;3".
        
        public string WorkflowIdList { get; set; } //// format: "1;2;3".
        
        public string GroupTransIdList { get; set; } ////format: "1,2,3;  2,3,4; ".

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "SPU_SuspiciousInfoInsert";
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
