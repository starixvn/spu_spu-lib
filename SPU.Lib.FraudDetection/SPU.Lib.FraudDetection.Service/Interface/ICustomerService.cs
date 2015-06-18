using System.Collections.Generic;
using Fanex.Data.Repository;

namespace SPU.Lib.FraudDetection.Service.Interface
{
    public interface ICustomerService
    {
        IDictionary<int, string> GetUsernameByCustId(ICriteria criteria);
    }
}