// --------------------------------------------------------------------------
// <copyright file="ICustomerDetailsReportDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.12.14">Created</change>
// </history>

namespace FD.Lib.DataAccess.Interface
{
    using Criteria.Reports.CustomerDetails;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using Model.Reports.CustomerDetails;
    using System.Collections.Generic;

    /// <summary>
    /// Customer Details Report Data Access interface.
    /// </summary>
    public interface ICustomerDetailsReportDataAccess
    {
        CustomerDetailsModel GetCustomerDetailWinlossStatistic(CustomerDetailsReportWinlossStatisticCriteria criteria);

        string GetTransListByCustId(CustomerDetailsReportTransListCriteria criteria);

        ICommandResult InsertCustomerLog(ICriteria criteria);

        ICommandResult InsertCustomerNote(ICriteria criteria);

        ICommandResult UpdateCustomerDelinquent(ICriteria criteria);

        ICommandResult InsertAssignees(ICriteria criteria);

        List<int> GetViolatedCases(ICriteria criteria);
    }
}