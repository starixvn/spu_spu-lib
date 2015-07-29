// --------------------------------------------------------------------------
// <copyright file="SuspiciousStatisticViewModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DTO.ReportTemplate
{
    using System.Collections.Generic;

    public class SuspiciousStatisticViewModel
    {
        public SuspiciousStatisticViewModel()
        {
            MarginCustormers = new List<MarginCustormer>();
            SuspiciousCustormers = new List<SuspiciousCustormer>();
        }

        public IList<MarginCustormer> MarginCustormers { get; set; }

        public IList<SuspiciousCustormer> SuspiciousCustormers { get; set; }
    }
}