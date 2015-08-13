// --------------------------------------------------------------------------
// <copyright file="SuspiciousCustomerTimeModel.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.24">Created</change>
// </history>

namespace FD.Lib.Model.Reports.SuspiciousCustomer
{
    /// <summary>
    /// The class SuspiciousCustomerTime.
    /// </summary>
    public class SuspiciousCustomerTimeModel
    {
        public int CustId { get; set; }

        public int SuspiciousTime { get; set; }
    }
}