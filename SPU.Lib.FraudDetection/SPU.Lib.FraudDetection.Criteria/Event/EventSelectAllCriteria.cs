// --------------------------------------------------------------------------
// <copyright file="EventSelectAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria
{
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// EventSelectAllCriteria Class.
    /// </summary>
    public class EventSelectAllCriteria : CriteriaBase
    {        
        public override string GetSettingKey()
        {
            return "SPU_EventSelectAll";
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
