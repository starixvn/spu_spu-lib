// --------------------------------------------------------------------------
// <copyright file="ICustomerReportDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.24">Created</change>
// </history>
namespace FD.Lib.DataAccess.Interface
{
    using System.Collections.Generic;
    using Fanex.Data.Repository;
    using Model.Reports.SuspiciousCustomer;

    /// <summary>
    /// Report Data Access interface.
    /// </summary>
    public interface ICustomerReportDataAccess
    {
        IEnumerable<SuspiciousCustomerReportModel> GetSuspiciousCustomersByGroup(ICriteria criteria);
    }
}