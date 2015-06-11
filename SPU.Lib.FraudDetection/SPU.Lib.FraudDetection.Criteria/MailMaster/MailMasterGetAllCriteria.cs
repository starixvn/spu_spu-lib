// --------------------------------------------------------------------------
// <copyright file="MailMasterGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.09">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.MailMaster
{
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// MailMasterGetAllCriteria Class.
    /// </summary>
    public class MailMasterGetAllCriteria : CriteriaBase
    {
        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "SPU_MailMasterGetAll";
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
