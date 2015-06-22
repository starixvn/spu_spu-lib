using System.Collections.Generic;
using System.Linq;
using SPU.Lib.FraudDetection.Criteria.SuspiciousStatistic;
using SPU.Lib.FraudDetection.Criteria.Workflow;
using SPU.Lib.FraudDetection.DTO;
using SPU.Lib.FraudDetection.DTO.ReportTemplate;
using SPU.Lib.FraudDetection.Service.Interface;

namespace SPU.Lib.FraudDetection.Service.Implement
{
    public class ReportService : IReportService
    {
        public ICustomerService CustomerService { get; set; }

        public IMatchService MatchService { get; set; }

        public IWorkflowService WorkflowService { get; set; }

        public IBalanceUpDayService BalanceUpDayService { get; set; }

        public ReportService()
        {
            CustomerService = new CustomerService();
            MatchService = new MatchService();
            WorkflowService = new WorkflowService();
            BalanceUpDayService = new BalanceUpDayService();
        }

        public SuspiciousStatisticViewModel GetSuspiciousCustomerStatistics(IList<SuspiciousInfo> list)
        {
            var customers = GetDistinctCustomers(list);

            var matches = GetDistinctMatches(list);

            //var margins = GetMarginCustomer(list);

            var model = BuildSuspiciousStatisticViewModel(list, matches, customers);

            return model;
        }

        private IList<object> GetMarginCustomer(IList<SuspiciousInfo> list)
        {
            var balanceUpDay = BalanceUpDayService.GetBalanceUpDay(new BalanceUpDaySelectCriteria()).BalanceUpDay;

            var criteria = new MarginCustomerSelectCriteria
            {
                BalanceUpDay = balanceUpDay,
                ListCustIDs = string.Join(",", list.Select(t => t.CustId).Distinct().ToList())
            };

            var margins = CustomerService.GetMarginCustomerByCustId(criteria);
            var groupByCustId = margins.GroupBy(t => t.CustId);

            return null;
        }

        private SuspiciousStatisticViewModel BuildSuspiciousStatisticViewModel(IList<SuspiciousInfo> list, IList<MatchDetail> matches,
            IDictionary<int, string> customers)
        {
            var model = new SuspiciousStatisticViewModel();

            var workflow = WorkflowService.GetWorkflowById(new WorkflowSelectByIdCriteria()
            {
                WorkflowId = list[0].WorkflowId
            });

            if (customers.Count == 0 || matches.Count == 0)
            {
                return model;
            }

            foreach (var item in list)
            {
                var match = matches.FirstOrDefault(t => t.MatchId == item.MatchId);

                if (match != null)
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

            return model;
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

            if (matches.Count != matchCount)
            {
                criteria.IsDbArchieve = true;
                matches = MatchService.GetMatchDetails(criteria).ToList();
            }

            return matches;
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
    }
}