namespace FD.Lib.Service.Implement
{
    using System.Collections.Generic;
    using Criteria.SuspiciousInfo;
    using Fanex.NAP.Framework.Command;

    public interface ISuspiciousCustomerService
    {
        ICommandResult InsertSuspiciousCustomer(SuspiciousCustomerInsertCriteria criteria);

        IList<int> GetNewSuspiciousCustomers(NewSuspiciousCustomersGetCriteria criteria);
    }
}