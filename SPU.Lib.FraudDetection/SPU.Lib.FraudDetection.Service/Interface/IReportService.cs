namespace FD.Lib.Service.Interface
{
    using System.Collections.Generic;
    using DTO;
    using DTO.ReportTemplate;

    public interface IReportService
    {
        SuspiciousStatisticViewModel GetSuspiciousCustomerStatistics(IList<SuspiciousInfo> list);
    }
}