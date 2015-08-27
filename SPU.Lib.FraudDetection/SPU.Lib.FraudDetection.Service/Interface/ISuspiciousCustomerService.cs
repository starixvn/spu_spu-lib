namespace FD.Lib.Service.Interface
{
    using System.Collections.Generic;
    using Criteria.SuspiciousInfo;
    using Criteria.SuspiciousStatistic;
    using DTO;
    using Fanex.NAP.Framework.Command;

    public interface ISuspiciousCustomerService
    {
        ICommandResult InsertSuspiciousCustomer(SuspiciousCustomerInsertCriteria criteria);

        IList<int> GetNewSuspiciousCustomers(NewSuspiciousCustomersGetCriteria criteria);

        IList<Customer> GetSuspiciousCustomerById(SuspiciousCustomerGetByIdCriteria criteria);
    }
}