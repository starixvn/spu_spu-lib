namespace FD.Lib.Service.Implement
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.SuspiciousInfo;
    using Criteria.SuspiciousStatistic;
    using DTO;
    using Fanex.NAP.Framework.Command;
    using Interface;

    public class SuspiciousCustomerService : QueryService, ISuspiciousCustomerService
    {
        public ICommandResult InsertSuspiciousCustomer(SuspiciousCustomerInsertCriteria criteria)
        {
            return ExecuteNonQuery(criteria);
        }

        public IList<int> GetNewSuspiciousCustomers(NewSuspiciousCustomersGetCriteria criteria)
        {
            return GetData<int>(criteria).ToList();
        }

        public IList<Customer> GetSuspiciousCustomerById(SuspiciousCustomerGetByIdCriteria criteria)
        {
            return GetData<Customer>(criteria).ToList();
        }
    }
}