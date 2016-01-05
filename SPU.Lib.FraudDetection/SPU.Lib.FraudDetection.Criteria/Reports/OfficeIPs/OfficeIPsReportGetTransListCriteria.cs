// --------------------------------------------------------------------------
// <copyright file="OfficeIPsReportGetTransListCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2016.01.05">Created</change>
// </history>

namespace FD.Lib.Criteria.Reports.OfficeIPs
{
    using System;
    using Fanex.Data.Repository;

    /// <summary>
    /// Customer Detail Report Criteria.
    /// </summary>
    public class OfficeIPsReportGetTransListCriteria : CriteriaBase
    {
        public int CaseId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public override bool IsValid()
        {
            return CaseId > 0;
        }

        public override string GetSettingKey()
        {
            return "FD_OfficeIPsTransListGetByCaseId";
        }
    }
}
