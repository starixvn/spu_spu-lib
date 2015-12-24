// --------------------------------------------------------------------------
// <copyright file="CustomerDetailsAssigneesInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.12.23">Created</change>
// </history>

namespace FD.Lib.Criteria.Reports.CustomerDetails
{
    using Fanex.Data.Repository;

    /// <summary>
    /// Customer Detail Report
    /// </summary>
    public class CustomerDetailsAssigneesInsertCriteria : CriteriaBase
    {
        public int CustId { get; set; }

        public string Assignees { get; set; }

        public int AuthorId { get; set; }

        /// <summary>
        /// Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_CustomerDetailsAssigneesInsert";
        }

        /// <summary>
        /// Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return CustId > 0 && AuthorId > 0;
        }
    }
}
