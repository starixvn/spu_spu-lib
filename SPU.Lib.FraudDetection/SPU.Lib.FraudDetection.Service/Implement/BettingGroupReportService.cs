// --------------------------------------------------------------------------
// <copyright file="MatchMonitoringReportService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.08.12">Created</change>
// </history>

namespace FD.Lib.Service.Implement
{
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.Reports;
    using DataAccess.Implement;
    using DataAccess.Interface;
    using DTO;
    using Fanex.Data.Repository;
    using Interface;
    using Model.Reports.BettingGroup;

    /// <summary>
    /// Match Monitoring Service.
    /// </summary>
    public class BettingGroupReportService : QueryService, IBettingGroupReportService
    {
        public IList<AssociationCustomer> GetAssociationCustomers(AssociationCustomersGetCriteria criteria)
        {
            var result = GetData<RawAssociationCustomer>(criteria);

            var groups = result.GroupBy(t => new {t.MatchId, t.GroupingOption});

            var finalResult = new List<AssociationCustomer>();

            foreach (var group in groups)
            {
                var associationCustomers = string.Join(", ",
                    group.Where(t => t.CustId != criteria.CustId).Select(t => t.CustName));
                associationCustomers = group.Single(t => t.CustId == criteria.CustId).CustName + ", " + associationCustomers;

                var associationTransactions = string.Join(",", group.Select(t => t.TransIds));
                var sumwl = GetSumWinLossOfAssociationTransactions(associationTransactions);

                sumwl.AssociationMembers = associationCustomers;
                finalResult.Add(sumwl);
            }

            return finalResult;
        }

        private AssociationCustomer GetSumWinLossOfAssociationTransactions(string associationTransactions)
        {
            var criteriaForBodb02 = new SumWinLossByTransIdsGetCriteria
            {
                TransList = associationTransactions
            };

            var resultFromBodb02 = GetData<AssociationCustomer>(criteriaForBodb02).ToList();

            if (resultFromBodb02.Count > 0)
            {
                return resultFromBodb02.Single();
            }

            var criteriaForBodbArchieve = new SumWinLossByTransIdsGetFromDBArchiveCriteria
            {
                TransList = associationTransactions
            };

            var resultFromBodbArchieve = GetData<AssociationCustomer>(criteriaForBodbArchieve).ToList();

            return resultFromBodbArchieve.Count > 0 ? resultFromBodbArchieve.Single() : null;
        }
    }
}