// --------------------------------------------------------------------------
// <copyright file="MailMasterGetByIdCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.11">Created</change>
// </history>

namespace FD.Lib.Criteria.MailMaster
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     MailMasterGetByIdCriteria Class.
    /// </summary>
    public class MailMasterGetByIdCriteria : CriteriaBase
    {
        public int MailId { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_MailMasterGetById";
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