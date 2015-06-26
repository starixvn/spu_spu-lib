// --------------------------------------------------------------------------
// <copyright file="CustomerReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------

namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.Reports;
    using Criteria.SuspiciousStatistic;
    using DataAccess.Implement;
    using DTO;
    using DTO.Reports;
    using Interface;

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
        public IEnumerable<SuspiciousCustomerReport> GetAllSuspiciousCustomerReport(SuspiciousCustomerReportGetAllCriteria criteria)
        {
            var suspiciousCustomers = GetSuspiciousCustomerByGroup(criteria.GroupId);
            var customers = GetCustomers(GetSuspiciousCustomerIds(suspiciousCustomers));
            var filteredCustomers = FilterCustomersByName(criteria.CustName, customers);
            var filteredSuspiciousCustomers = GetFilteredSuspiciousCustomers(suspiciousCustomers, filteredCustomers);
            var suspiciousCustomerTime = GetSuspiciousCustomerTime(GetSuspiciousCustomerIds(filteredSuspiciousCustomers));

            foreach (var filteredCuspiciousCustomer in filteredSuspiciousCustomers)
            {
                foreach (var suspiciousCustomer in suspiciousCustomerTime)
                {
                    if (suspiciousCustomer.CustId == filteredCuspiciousCustomer.Customer.CustId)
                    {
                        filteredCuspiciousCustomer.SuspiciousTime = suspiciousCustomer.SuspiciousTime;
                    }
                }
            }

            var marginCustomers = GetSuspiciousCustomerMargin(GetSuspiciousCustomerIds(filteredSuspiciousCustomers));

            var result = BindMarginData(filteredSuspiciousCustomers, marginCustomers);

            return result;
        }

        /// <summary>
        /// The method BindMarginData.
        /// </summary>
        /// <param name="customers">List customers.</param>
        /// <param name="margins">List margins.</param>
        /// <returns>The bind data.</returns>
        private IEnumerable<SuspiciousCustomerReport> BindMarginData(
            IEnumerable<SuspiciousCustomerReport> customers,
            IList<RawMarginCustomer> margins)
        {
            var startMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-2);
            for (var i = 0; i < 3; i++)
            {
                var month = startMonth.AddMonths(i);

                foreach (var customer in customers)
                {
                    var margin = decimal.Round(GetMargin(customer.Customer.CustId, month, margins) * 100, 2);
                    var winLoss = decimal.Round(GetWinLoss(customer.Customer.CustId, month, margins) * 100, 2);

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
        private decimal GetMargin(int custId, DateTime month, IList<RawMarginCustomer> margins)
        {
            foreach (var margin in margins)
            {
                if (margin.CustId == custId && new DateTime(margin.SuspiciousYear, margin.SuspiciousMonth, 1) == month)
                {
                    return margin.Margin != null ? (decimal)margin.Margin : 0;
                }
            }

            return 0;
        }

        /// <summary>
        /// Get win loss.
        /// </summary>
        /// <param name="custId">Customer ID.</param>
        /// <param name="month">The month wanted to get.</param>
        /// <param name="margins">List Margins.</param>
        /// <returns>WinLoss of month.</returns>
        private decimal GetWinLoss(int custId, DateTime month, IList<RawMarginCustomer> margins)
        {
            foreach (var margin in margins)
            {
                if (margin.CustId == custId && new DateTime(margin.SuspiciousYear, margin.SuspiciousMonth, 1) == month)
                {
                    return margin.MemberWinlost != null ? (decimal)margin.MemberWinlost : 0;
                }
            }

            return 0;
        }

        private IEnumerable<Customer> FilterCustomersByName(string custName, IList<Customer> customers)
        {
            return from c in customers where c.CustName.ToLower().Contains(custName.ToLower()) select c;
        }

        private IEnumerable<SuspiciousCustomerTime> GetSuspiciousCustomerTime(string listCustIds)
        {
            var criteria = new SuspiciousCustomerTimeGetAllCriteria()
            {
                ListCustIds = listCustIds
            };

            return GetData<SuspiciousCustomerTime>(criteria);
        }

        private IList<RawMarginCustomer> GetSuspiciousCustomerMargin(string listCustIds)
        {
            var marginCriteria = new MarginCustomerSelectCriteria()
            {
                ListCustIDs = listCustIds
            };

            return _customerService.GetMarginCustomerByCustId(marginCriteria);
        }

        /// <summary>
        /// Get filtered customers.
        /// </summary>
        /// <param name="suspiciousCustomers">The input suspicious customers.</param>
        /// <param name="customers">The input customers.</param>
        /// <returns>List filtered customers.</returns>
        private IEnumerable<SuspiciousCustomerReport> GetFilteredSuspiciousCustomers(
            IEnumerable<SuspiciousCustomerReport> suspiciousCustomers,
            IEnumerable<Customer> customers)
        {
            var result = new List<SuspiciousCustomerReport>();
            foreach (var customer in customers)
            {
                foreach (var suspiciousCustomer in suspiciousCustomers)
                {
                    if (suspiciousCustomer.Customer.CustId == customer.CustId)
                    {
                        suspiciousCustomer.Customer = customer;
                        result.Add(suspiciousCustomer);
                    }
                }
            }

            return result;
        }

        private IEnumerable<SuspiciousCustomerReport> GetSuspiciousCustomerByGroup(int groupId)
        {
            var suspiciousCustomerGetByGroupCriteria = new SuspiciousCustomerGetByGroupCriteria
            {
                GroupId = groupId
            };

            return _reportDataAccess.GetSuspiciousCustomersByGroup(suspiciousCustomerGetByGroupCriteria);
        }

        private IList<Customer> GetCustomers(string listCustIds)
        {
            var customerSelectCritiria = new CustomerSelectCritiria
            {
                ListCustIds = listCustIds
            };

            return _customerService.GetUsernameByCustId(customerSelectCritiria);
        }

        private string GetSuspiciousCustomerIds(IEnumerable<SuspiciousCustomerReport> customers)
        {
            var distinctCustomers = customers.Select(t => t.Customer.CustId).Distinct().ToList();
            var result = string.Join(",", distinctCustomers);

            return result;
        }
    }
}