namespace SPU.Lib.FraudDetection.Service.Implement
{
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.SuspiciousStatistic;
    using DTO;
    using Fanex.Data.Repository;
    using Interface;

    public class CustomerService : QueryService, ICustomerService
    {
        public CustomerService()
        {
            BalanceUpDayService = new BalanceUpDayService();
        }

        public IBalanceUpDayService BalanceUpDayService { get; set; }

        public IList<Customer> GetUsernameByCustId(ICriteria criteria)
        {
            return GetData<Customer>(criteria).ToList();
        }

        public IList<RawMarginCustomer> GetMarginCustomerByCustId(MarginCustomerSelectCriteria criteria)
        {
            criteria.BalanceUpDay = BalanceUpDayService.GetBalanceUpDay(new BalanceUpDaySelectCriteria()).BalanceUpDay;

            return GetData<RawMarginCustomer>(criteria).ToList();
        }
    }
}