// --------------------------------------------------------------------------
// <copyright file="CustomerService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Service.Implement
{
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.SuspiciousStatistic;
    using DTO;
    using Fanex.Data.Repository;
    using Interface;

    public class CustomerService : QueryService, ICustomerService
    {
        public CustomerService()
        {
            BalanceUpDayService = new MoveBetsBalanceUpService();
        }

        public IMoveBetsBalanceUpService BalanceUpDayService { get; set; }

        public IList<Customer> GetUsernameByCustId(ICriteria criteria)
        {
            return GetData<Customer>(criteria).ToList();
        }

        public IList<RawMarginCustomer> GetMarginCustomerByCustId(CustomerWinlostSelectCriteria criteria)
        {
            return GetData<RawMarginCustomer>(criteria).ToList();
        }
    }
}