// --------------------------------------------------------------------------
// <copyright file="ICustomerService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service.Interface
{
    using System.Collections.Generic;
    using Criteria.SuspiciousStatistic;
    using DTO;
    using Fanex.Data.Repository;

    public interface ICustomerService
    {
        IList<Customer> GetUsernameByCustId(ICriteria criteria);

        IList<RawMarginCustomer> GetMarginCustomerByCustId(CustomerWinlostSelectCriteria criteria);
    }
}