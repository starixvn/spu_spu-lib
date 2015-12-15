// --------------------------------------------------------------------------
// <copyright file="CustomerNoteInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.12.14">Created</change>
// </history>

namespace FD.Lib.Criteria.Reports.CustomerDetails
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Customer Detail Report - Customer Note Insert Criteria.
    /// </summary>
    public class CustomerNoteInsertCriteria : CriteriaBase
    {
        public int CustId { get; set; }

        public int CaseId { get; set; }

        public int AuthorId { get; set; }

        public string LogDesc { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_CustomerNoteInsert";
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
