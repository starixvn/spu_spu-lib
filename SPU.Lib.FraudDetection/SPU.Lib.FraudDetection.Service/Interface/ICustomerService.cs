namespace SPU.Lib.FraudDetection.Service.Interface
{
    using System.Collections.Generic;
    using Criteria.SuspiciousStatistic;
    using Fanex.Data.Repository;

    public interface ICustomerService
    {
        IList<Customer> GetUsernameByCustId(ICriteria criteria);
        IList<RawMarginCustomer> GetMarginCustomerByCustId(MarginCustomerSelectCriteria criteria);
    }
}