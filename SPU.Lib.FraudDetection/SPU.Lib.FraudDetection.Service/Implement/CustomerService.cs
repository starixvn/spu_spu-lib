namespace FD.Lib.Service.Implement
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

        public IList<RawMarginCustomer> GetMarginCustomerByCustId(CustomerWinlostSelectCriteria criteria)
        {
            return GetData<RawMarginCustomer>(criteria).ToList();
        }
    }
}