// --------------------------------------------------------------------------
// <copyright file="MarginCustormer.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DTO.ReportTemplate
{
    using System.Collections.Generic;

    public class MarginCustormer
    {
        public MarginCustormer()
        {
            Margins = new List<decimal?>();
        }

        public string Member { get; set; }

        public IList<decimal?> Margins { get; set; }
    }
}