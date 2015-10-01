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
    using DTO;
    using Model.Reports.BettingGroup;

    /// <summary>
    /// Match Monitoring Service.
    /// </summary>
    public class BettingGroupReportService : QueryService, IBettingGroupReportService
    {
        public IList<AssociationCustomer> GetAssociationCustomers(AssociationCustomersGetCriteria criteria)
        {
            var result = GetData<RawAssociationCustomer>(criteria);

            var groups = result.GroupBy(t => new { t.MatchId, t.GroupingOption });

            var finalResult = new List<AssociationCustomer>();

            foreach (var group in groups)
            {
                var associationCustomers = string.Join(", ",
                    group.Where(t => t.CustId != criteria.CustId).Select(t => t.CustName));
                associationCustomers = group.First(t => t.CustId == criteria.CustId).CustName + ", " + associationCustomers;

                var associationTransactions = string.Join(",", group.Select(t => t.TransIds));
                var results = GetSumWinLossOfAssociationTransactions(associationCustomers, associationTransactions);

                finalResult.AddRange(results);
            }

            return finalResult;
        }

        private IList<AssociationCustomer> GetSumWinLossOfAssociationTransactions(string associationCustomers, string associationTransactions)
        {
            var criteriaForBodb02 = new SumWinLossByTransIdsGetCriteria
            {
                TransList = associationTransactions
            };

            var resultFromBodb02 = GetData<AssociationCustomer>(criteriaForBodb02).ToList();

            if (resultFromBodb02.Count > 0)
            {
                foreach (var sumwl in resultFromBodb02)
                {
                    sumwl.AssociationMembers = associationCustomers;
                }

                return resultFromBodb02;
            }

            var criteriaForBodbArchieve = new SumWinLossByTransIdsGetFromDbArchiveCriteria
            {
                TransList = associationTransactions
            };

            var resultFromBodbArchieve = GetData<AssociationCustomer>(criteriaForBodbArchieve).ToList();

            foreach (var sumwl in resultFromBodbArchieve)
            {
                sumwl.AssociationMembers = associationCustomers;
            }

            return resultFromBodbArchieve.Count > 0 ? resultFromBodbArchieve : new List<AssociationCustomer>();
        }
    }
}