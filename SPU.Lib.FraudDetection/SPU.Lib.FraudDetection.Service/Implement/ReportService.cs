namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.SuspiciousStatistic;
    using Criteria.Workflow;
    using DTO;
    using DTO.ReportTemplate;
    using Interface;

    public class ReportService : IReportService
    {
        public ReportService()
        {
            CustomerService = new CustomerService();
            MatchService = new MatchService();
            WorkflowService = new WorkflowService();
            BalanceUpDayService = new BalanceUpDayService();
        }

        public IBalanceUpDayService BalanceUpDayService { get; set; }
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
            IDictionary<int, string> customers, IList<MarginCustormer> margins)
        {
            var model = new SuspiciousStatisticViewModel();

            var workflow = WorkflowService.GetWorkflowById(new WorkflowSelectByTaskIdCriteria
            {
                TaskId = list[0].TaskId
            });

            if (customers.Count == 0 || matches.Count == 0)
            {
                return model;
            }

            foreach (var item in list)
            {
                var match = matches.FirstOrDefault(t => t.MatchId == item.MatchId);

                if (match != null && customers.ContainsKey(item.CustId))
                {
                    model.SuspiciousCustormers.Add(new SuspiciousCustormer
                    {
                        Member = customers[item.CustId],
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

            model.MarginCustormers = margins;

            return model;
        }

        private IDictionary<int, string> GetDistinctCustomers(IList<SuspiciousInfo> list)
        {
            var distinctCustomers = list.Select(t => t.CustId).Distinct().ToList();

            var customers = CustomerService.GetUsernameByCustId(new CustomerSelectCritiria
            {
                ListCustIds = string.Join(",", distinctCustomers)
            });

            return customers;
        }

        private IList<MatchDetail> GetDistinctMatches(IList<SuspiciousInfo> list)
        {
            var distinctMatches = list.Select(t => t.MatchId).Distinct().ToList();
            var matchCount = distinctMatches.Count;

            var criteria = new MatchSelectCriteria
            {
                ListMatchIds = string.Join(",", distinctMatches)
            };

            var matches = MatchService.GetMatchDetails(criteria).ToList();

            if (matches.Count < matchCount)
            {
                criteria.IsDbArchieve = true;
                matches.AddRange(MatchService.GetMatchDetails(criteria));
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
            var balanceUpDay = BalanceUpDayService.GetBalanceUpDay(new BalanceUpDaySelectCriteria()).BalanceUpDay;

            var criteria = new MarginCustomerSelectCriteria
            {
                BalanceUpDay = balanceUpDay,
                ListCustIDs = string.Join(",", list.Select(t => t.CustId).Distinct().ToList())
            };

            var last3Months = GetLast3Months();

            var margins = CustomerService.GetMarginCustomerByCustId(criteria).OrderBy(t => t.Username);

            var groupByCustId = margins.GroupBy(t => t.Username);

            var marginList = new List<MarginCustormer>();

            foreach (var group   in groupByCustId)
            {
                var margin = new MarginCustormer {Member = @group.Key};

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