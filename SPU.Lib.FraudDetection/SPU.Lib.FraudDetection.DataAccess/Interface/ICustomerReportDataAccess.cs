// --------------------------------------------------------------------------
// <copyright file="ICustomerReportDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.24">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess.Interface
{
    using System.Collections.Generic;
    using Fanex.Data.Repository;
    using SPU.Lib.FraudDetection.DTO.Reports;

    /// <summary>
    /// Report Data Access interface.
    /// </summary>
    public interface ICustomerReportDataAccess
    {
        IEnumerable<SuspiciousCustomerReport> GetAllSuspiciousCustomerReport(ICriteria criteria);
    }
}
