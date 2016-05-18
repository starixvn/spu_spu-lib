// --------------------------------------------------------------------------
// <copyright file="CustomerInfo.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.12.14">Created</change>
// </history>

namespace FD.Lib.DTO.CustomerDetails
{
    public class CustomerInfo
    {
        public int CustId { get; set; }

        public string UserName { get; set; }

        public string CurrencyCode { get; set; }

        public bool IsDelinquent { get; set; }

        public bool IsHedge { get; set; }
    }
}