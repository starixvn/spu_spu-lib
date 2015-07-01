namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Criteria.SuspiciousStatistic;
    using Criteria.Workflow;
    using DTO;
    using DTO.ReportTemplate;
    using Interface;

    public class SuspiciousStatisticsReportService : IReportService
    {
        public SuspiciousStatisticsReportService()
        {
            CustomerService = new CustomerService();
            MatchService = new MatchService();
            WorkflowService = new WorkflowService();
        }

        public ICustomerService CustomerService { get; set; }
        public IMatchService MatchService { get; set; }
        public IWorkflowService WorkflowService { get; set; }

        public SuspiciousStatisticViewModel GetSuspiciousCustomerStatistics(IList<SuspiciousInfo> list)
        {
            var customers = GetDistinctCustomers(list);

            var matches = GetDistinctMatches(list);

            var margins = GetMarginCustomer(list);

            var model = BuildSuspiciousStatisticViewModel(list, matches, customers, margins);

            return model;
        }

        #region Private methods

        private SuspiciousStatisticViewModel BuildSuspiciousStatisticViewModel(IList<SuspiciousInfo> list,
            IList<MatchDetail> matches,
            IList<Customer> customers, IList<MarginCustormer> margins)
        {
            if (customers.Count == 0 || matches.Count == 0)
            {
                return new SuspiciousStatisticViewModel();
            }

            var model = new SuspiciousStatisticViewModel();

            var workflow = WorkflowService.GetWorkflowById(new WorkflowSelectByIdCriteria
            {
                WorkflowId = list[0].WorkflowId
            });

            var suspiciousCustomer = new List<SuspiciousCustormer>();

            foreach (var item in list)
            {
                var match = matches.FirstOrDefault(t => t.MatchId == item.MatchId);

                if (match != null && customers.Any(t => t.CustId == item.CustId))
                {
                    suspiciousCustomer.Add(new SuspiciousCustormer
                    {
                        Member = customers.Single(t => t.CustId == item.CustId).CustName,
                        MatchId = match.MatchId,
                        MatchCode = match.MatchCode,
                        EventDate = match.EventDate,
                        League = match.LeagueName,
                        Sport = match.SportName,
                        Workflow = workflow.WorkflowName,
                        Event = string.Format("{0} -vs- {1}", match.HomeName, match.AwayName)
                    });
                }
            }

            model.SuspiciousCustormers = suspiciousCustomer.OrderBy(t => t.Member).ToList();

            model.MarginCustormers = margins;

            return model;
        }

        protected int ChunkSize = 60;

        private IList<Customer> GetDistinctCustomers(IList<SuspiciousInfo> list)
        {
            var distinctCustomers = list.Select(t => t.CustId).Distinct().ToList();
            var customerChunks = distinctCustomers.Chunk(ChunkSize);
            var customers = new List<Customer>();

            foreach (var customerChunk in customerChunks)
            {
                customers.AddRange(CustomerService.GetUsernameByCustId(new CustomerSelectCritiria
                {
                    ListCustIds = string.Join(",", customerChunk)
                }));
            }

            return customers;
        }

        private IList<MatchDetail> GetDistinctMatches(IList<SuspiciousInfo> list)
        {
            var distinctMatches = list.Select(t => t.MatchId).Distinct().ToList();
            var matchCount = distinctMatches.Count;
            var matches = new List<MatchDetail>();

            matches.AddRange(GetMatchesFromBodb02(distinctMatches));

            if (matches.Count < matchCount)
            {
                matches.AddRange(GetMatchesFromBodb02(distinctMatches, true));
            }

            return matches;
        }

        private IList<MatchDetail> GetMatchesFromBodb02(IList<int> distinctMatches, bool IsDbArchive = false)
        {
            var matchChunks = distinctMatches.Chunk(ChunkSize);
            var matches = new List<MatchDetail>();

            foreach (var matchChunk in matchChunks)
            {
                var criteria = new MatchSelectCriteria
                {
                    IsDbArchieve = IsDbArchive,
                    ListMatchIds = string.Join(",", distinctMatches)
                };

                matches.AddRange(MatchService.GetMatchDetails(criteria).ToList());
            }

            return matches;
        }

        private List<DateTime> GetLast3Months()
        {
            var last3Months = new List<DateTime>();
            var today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            for (var i = 2; i >= 0; i--)
            {
                last3Months.Add(today.AddMonths(-i));
            }
            return last3Months;
        }

        private IList<MarginCustormer> GetMarginCustomer(IList<SuspiciousInfo> list)
        {
            var criteria = new CustomerWinlostSelectCriteria
            {
                ListCustIDs = string.Join(",", list.Select(t => t.CustId).Distinct().ToList())
            };

            var last3Months = GetLast3Months();

            var margins = CustomerService.GetMarginCustomerByCustId(criteria).OrderBy(t => t.Username);

            var groupByCustId = margins.GroupBy(t => t.Username);

            var marginList = new List<MarginCustormer>();

            foreach (var group in groupByCustId)
            {
                var margin = new MarginCustormer { Member = @group.Key };

                foreach (var month in last3Months)
                {
                    var temp = group.SingleOrDefault(t => t.WinlostDate.Equals(month));
                    margin.Margins.Add(temp == null ? null : temp.Margin);
                }

                marginList.Add(margin);
            }

            return marginList;
        }

        #endregion
    }
}