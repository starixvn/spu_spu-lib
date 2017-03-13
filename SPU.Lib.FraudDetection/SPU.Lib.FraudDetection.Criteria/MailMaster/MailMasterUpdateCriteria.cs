// --------------------------------------------------------------------------
// <copyright file="MailMasterUpdateCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.09">Created</change>
// </history>

namespace FD.Lib.Criteria.MailMaster
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Fanex.Data.Repository;

    /// <summary>
    ///     MailMasterUpdateCriteria Class.
    /// </summary>
    public class MailMasterUpdateCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public int MailId { get; set; }

        [DisplayName("Mailing List")]
        [Required(ErrorMessage = "Mailing List Required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Mailing List must be a positive number")]
        public int MailingListId { get; set; }

        [Required(ErrorMessage = "Mail Code Required.")]
        [RegularExpression(@"^[\S]*$", ErrorMessage = "White space found.")]
        public string MailCode { get; set; }

        public string MailDesc { get; set; }

        [Required(ErrorMessage = "Subject Required.")]
        public string MailSubject { get; set; }

        public string MailContent { get; set; }

        [Required(ErrorMessage = "Mailing To Required.")]
        [SpParam(Ignored = true)]
        public string To { get; set; }

        [SpParam(Ignored = true)]
        public string CcTo { get; set; }

        [SpParam(Ignored = true)]
        public string BccTo { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_MailMasterUpdate";
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