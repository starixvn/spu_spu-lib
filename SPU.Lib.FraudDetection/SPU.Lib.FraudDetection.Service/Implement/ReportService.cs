using System.Collections.Generic;
using System.Linq;
using SPU.Lib.FraudDetection.Criteria.SuspiciousStatistic;
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

        public ReportService()
        {
            CustomerService = new CustomerService();
            MatchService = new MatchService();
            WorkflowService = new WorkflowService();
        }

        public SuspiciousStatisticViewModel GetSuspiciousCustomerStatistics(IList<SuspiciousInfo> list)
        {
            var customers = GetDistinctCustomers(list);

            var matches = GetDistinctMatches(list);

            var model = BuildSuspiciousStatisticViewModel(list, matches, customers);

            return model;
        }

        private SuspiciousStatisticViewModel BuildSuspiciousStatisticViewModel(IList<SuspiciousInfo> list, IEnumerable<MatchDetail> matches,
            IDictionary<int, string> customers)
        {
            var model = new SuspiciousStatisticViewModel();

            foreach (var item in list)
            {
                var match = matches.Single(t => t.MatchId == item.MatchId);

                model.SuspiciousCustormers.Add(new SuspiciousCustormer
                {
                    Member = customers[item.CustId],
                    MatchId = match.MatchId,
                    MatchCode = match.MatchCode,
                    EventDate = match.EventDate,
                    League = match.LeagueName,
                    Sport = match.SportName,
                    Workflow = item.WorkflowId.ToString(),
                    Event = string.Format("{0} -vs- {1}", match.HomeName, match.AwayName)
                });
            }
            return model;
        }

        private IEnumerable<MatchDetail> GetDistinctMatches(IList<SuspiciousInfo> list)
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