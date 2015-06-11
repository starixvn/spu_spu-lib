// --------------------------------------------------------------------------
// <copyright file="MailMasterInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.09">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.MailMaster
{
    using System.ComponentModel.DataAnnotations;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// MailMasterInsertCriteria Class.
    /// </summary>
    public class MailMasterInsertCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        [Required(ErrorMessage = "Mail Code Required")]
        [RegularExpression(@"^[\S]*$", ErrorMessage = "White space found")]
        public string MailCode { get; set; }

        public string MailDescription { get; set; }

        [Required(ErrorMessage = "Subject Required")]
        public string MailSubject { get; set; }

        [Required(ErrorMessage = "Email Address Required")]
        public string MailAddressSentTo { get; set; }

        public string MailAddressCc { get; set; }

        public string MailAddressBcc { get; set; }

        public string MailContent { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "SPU_MailMasterIns";
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
