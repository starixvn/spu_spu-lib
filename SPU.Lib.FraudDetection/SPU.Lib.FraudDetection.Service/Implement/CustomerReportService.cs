// --------------------------------------------------------------------------
// <copyright file="CustomerReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------

namespace FD.Lib.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.Reports;
    using Criteria.SuspiciousStatistic;
    using DataAccess.Implement;
    using DTO;
    using Interface;
    using Model.Reports.SuspiciousCustomer;

    /// <summary>
    /// The class CustomerReportService.
    /// </summary>
    public class CustomerReportService : QueryService, ICustomerReportService
    {
        private readonly CustomerReportDataAccess _reportDataAccess;

        private readonly CustomerService _customerService;

        public CustomerReportService()
        {
            _reportDataAccess = new CustomerReportDataAccess();

            _customerService = new CustomerService();
        }

        /// <summary>
        /// Get all Suspicious Customers.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>The list of Suspicious Customers.</returns>
        public SuspiciousCustomerReportListModel GetAllSuspiciousCustomers(SuspiciousCustomerReportGetAllCriteria criteria)
        {
            var suspiciousCustomers = _reportDataAccess.GetAllSuspiciousCustomers(criteria);
            var marginCustomers = GetSuspiciousCustomerMargins(GetSuspiciousCustomerIds(suspiciousCustomers.SuspiciousCustomers));
            suspiciousCustomers.SuspiciousCustomers = BindMarginData(suspiciousCustomers.SuspiciousCustomers, marginCustomers);

            return suspiciousCustomers;
        }

        /// <summary>
        /// The method BindMarginData.
        /// </summary>
        /// <param name="customers">List customers.</param>
        /// <param name="margins">List margins.</param>
        /// <returns>The bind data.</returns>
        private IEnumerable<SuspiciousCustomerReportModel> BindMarginData(
            IEnumerable<SuspiciousCustomerReportModel> customers,
            IEnumerable<RawMarginCustomer> margins)
        {
            var startMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-2);
            for (var i = 0; i < 3; i++)
            {
                var month = startMonth.AddMonths(i);

                foreach (var customer in customers)
                {
                    var margin = GetMargin(customer.Customer.CustId, month, margins);
                    var winLoss = GetWinLoss(customer.Customer.CustId, month, margins);

                    customer.Margins.Add(margin);
                    customer.WinLoss.Add(winLoss);
                }
            }

            return customers;
        }

        /// <summary>
        /// Get margin from list.
        /// </summary>
        /// <param name="custId">Customer ID.</param>
        /// <param name="month">The month wanted to get.</param>
        /// <param name="margins">List Margins.</param>
        /// <returns>Margin of month.</returns>
        private decimal? GetMargin(int custId, DateTime month, IEnumerable<RawMarginCustomer> margins)
        {
            foreach (var margin in margins.Where(margin => margin.CustId == custId && margin.WinlostDate == month))
            {
                return margin.Margin;
            }

            return null;
        }

        /// <summary>
        /// Get win loss.
        /// </summary>
        /// <param name="custId">Customer ID.</param>
        /// <param name="month">The month wanted to get.</param>
        /// <param name="margins">List Margins.</param>
        /// <returns>WinLoss of month.</returns>
        private decimal? GetWinLoss(int custId, DateTime month, IEnumerable<RawMarginCustomer> margins)
        {
            foreach (var margin in margins.Where(margin => margin.CustId == custId && margin.WinlostDate == month))
            {
                return margin.MemberWinlost;
            }

            return null;
        }

        /// <summary>
        /// Get margin and win loss.
        /// </summary>
        /// <param name="listCustIds">List customer ID.</param>
        /// <returns>The list margin and win loss.</returns>
        private IEnumerable<RawMarginCustomer> GetSuspiciousCustomerMargins(string listCustIds)
        {
            var result = new List<RawMarginCustomer>().AsEnumerable();

            foreach (var customerIds in Split(listCustIds, 60))
            {
                var marginCriteria = new CustomerWinlostSelectCriteria
                {
                    ListCustIDs = customerIds
                };

                result = result.Concat(_customerService.GetMarginCustomerByCustId(marginCriteria));
            }

            return result;
        }

        private string GetSuspiciousCustomerIds(IEnumerable<SuspiciousCustomerReportModel> customers)
        {
            var distinctCustomers = customers.Select(t => t.Customer.CustId).Distinct().ToList();
            var result = string.Join(",", distinctCustomers);

            return result;
        }

        /// <summary>
        /// Split the data into small groups.
        /// </summary>
        /// <param name="source">The source data.</param>
        /// <param name="size">The size of group.</param>
        /// <returns>The result in list.</returns>
        private IEnumerable<string> Split(string source, int size)
        {
            var result = new List<string>();
            var newSource = source.Split(',').AsEnumerable();
            var groups = newSource.Select((x, i) => new { Index = i, Value = x })
                        .GroupBy(x => x.Index / size)
                        .Select(x => x.Select(v => v.Value).ToList())
                        .ToList();

            foreach (var group in groups)
            {
                result.Add(string.Join(",", group));
            }

            return result;
        }
    }
}