// --------------------------------------------------------------------------
// <copyright file="MailMasterGetByNameCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.11">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.MailMaster
{
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// MailMasterGetByNameCriteria Class.
    /// </summary>
    public class MailMasterGetByNameCriteria : CriteriaBase
    {
        public string MailCode { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "SPU_MailMasterGetByName";
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
