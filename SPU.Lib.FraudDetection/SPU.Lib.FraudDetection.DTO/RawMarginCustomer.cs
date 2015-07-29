// --------------------------------------------------------------------------
// <copyright file="RawMarginCustomer.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.DTO
{
    using System;

    public class RawMarginCustomer
    {
        public int CustId { get; set; }

        public string Username { get; set; }

        public decimal? MemberWinlost { get; set; }

        public decimal? Turnover { get; set; }

        public decimal? Margin
        {
            get
            {
                if (!MemberWinlost.HasValue)
                {
                    return null;
                }

                if (!Turnover.HasValue)
                {
                    return null;
                }

                return MemberWinlost.Value / Turnover.Value;
            }
        }

        public DateTime WinlostDate { get; set; }
    }
}