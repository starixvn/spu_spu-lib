namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.SuspiciousStatistic;
    using Fanex.Data.Repository;
    using Interface;

    public class CustomerService : QueryService, ICustomerService
    {
        public CustomerService()
        {
            BalanceUpDayService = new BalanceUpDayService();
        }

        public IBalanceUpDayService BalanceUpDayService { get; set; }

        public IDictionary<int, string> GetUsernameByCustId(ICriteria criteria)
        {
            var data = GetData<dynamic>(criteria);
            var dict = new Dictionary<int, string>();

            foreach (var row in data)
            {
                dict.Add(row.custid, row.username);
            }

            return dict;
        }

        public IList<RawMarginCustomer> GetMarginCustomerByCustId(MarginCustomerSelectCriteria criteria)
        {
            return GetData<RawMarginCustomer>(criteria).ToList();
        }
    }
}