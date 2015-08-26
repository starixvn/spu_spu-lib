namespace FD.Lib.Service.Implement
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Criteria.SuspiciousInfo;
    using Fanex.NAP.Framework.Command;

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
    }
}