using System.Collections.Generic;
using Fanex.Data.Repository;
using SPU.Lib.FraudDetection.Service.Interface;

namespace SPU.Lib.FraudDetection.Service.Implement
{
    public class CustomerService : QueryService, ICustomerService
    {
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
    }
}