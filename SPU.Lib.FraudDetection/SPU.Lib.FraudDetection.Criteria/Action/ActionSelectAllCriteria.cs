// --------------------------------------------------------------------------
// <copyright file="ActionSelectAllCriteria.cs" company="Nexcel Solutions Vietnam">
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
    /// ActionSelectAllCriteria Class.
    /// </summary>
    public class ActionSelectAllCriteria : CriteriaBase
    {        
        public override string GetSettingKey()
        {
            return "SPU_ActionSelectAll";
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
