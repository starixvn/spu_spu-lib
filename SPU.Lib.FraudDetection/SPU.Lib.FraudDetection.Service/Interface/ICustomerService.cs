using System.Collections.Generic;
using Fanex.Data.Repository;
using SPU.Lib.FraudDetection.Criteria.SuspiciousStatistic;

namespace SPU.Lib.FraudDetection.Service.Interface
{
    public interface ICustomerService
    {
        IDictionary<int, string> GetUsernameByCustId(ICriteria criteria);

        IList<RawMarginCustomer> GetMarginCustomerByCustId(MarginCustomerSelectCriteria criteria);

    }
}