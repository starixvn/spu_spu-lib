namespace FD.Lib.Service.Implement
{
    using System.Collections.Generic;
    using Criteria.Reports;
    using Model.Reports.BettingGroup;

    public interface IBettingGroupReportService
    {
        IList<AssociationCustomer> GetAssociationCustomers(AssociationCustomersGetCriteria criteria);
    }
}