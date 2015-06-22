using System.Collections.Generic;
using System.Linq;
using Fanex.Data.Repository;
using SPU.Lib.FraudDetection.Criteria.SuspiciousStatistic;
using SPU.Lib.FraudDetection.Service.Interface;

namespace SPU.Lib.FraudDetection.Service.Implement
{
    public class CustomerService : QueryService, ICustomerService
    {
        public IBalanceUpDayService BalanceUpDayService { get; set; }

        public CustomerService()
        {
            BalanceUpDayService = new BalanceUpDayService();
        }

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