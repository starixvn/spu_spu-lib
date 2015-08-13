namespace FD.Lib.Service.Interface
{
    using Criteria.Reports;
    using Model.Reports.FraudCaseDetail;
    using Model.Reports.SuspiciousCustomer;

    public interface IFraudCaseDetailReportService
    {
        FraudCaseDetailReportViewModel GetFraudCaseDetails(FraudCaseDetailReportCriteria criteria);
    }
}