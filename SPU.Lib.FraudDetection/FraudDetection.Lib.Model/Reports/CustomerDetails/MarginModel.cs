// --------------------------------------------------------------------------
// <copyright file="MarginModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.10.29">Created</change>
// </history>

namespace FD.Lib.Model.Reports.CustomerDetails
{
    using System;
    using System.Collections.Generic;
    using DTO.CustomerDetails;
    using FraudCaseDetail;

    /// <summary>
    /// Customer Details Model.
    /// </summary>
    [Serializable]
    public class MarginModel
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public decimal Turnover { get; set; }

        public decimal Winloss { get; set; }

        public decimal Margin
        {
            get
            {
                return Turnover == 0 ? 0 : Math.Round(Winloss / Turnover * 100, 2);
            }
        }

        public int BetCount { get; set; }
    }
}