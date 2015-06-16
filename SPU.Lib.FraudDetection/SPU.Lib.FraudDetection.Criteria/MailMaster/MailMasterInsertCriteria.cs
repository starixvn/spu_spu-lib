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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.Core;

    /// <summary>
    /// MailMasterInsertCriteria Class.
    /// </summary>
    public class MailMasterInsertCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        [DisplayName("Mailing List")]
        [Required(ErrorMessage = "Mailing List Required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Mailing List must be a positive number")]
        public int MailingListId { get; set; }

        [Required(ErrorMessage = "Mail Code Required.")]
        [RegularExpression(@"^[\S]*$", ErrorMessage = "White space found.")]
        [MailCodeUnique]
        public string MailCode { get; set; }

        public string MailDesc { get; set; }

        [Required(ErrorMessage = "Subject Required.")]
        public string MailSubject { get; set; }

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
