namespace FD.Lib.Service.Interface
{
    using Criteria.Reports;
    using Model.Reports.FraudCaseDetail;

    public interface IFraudCaseDetailReportService
    {
        FraudCaseDetailReportViewModel GetFraudCaseDetails(FraudCaseDetailReportCriteria criteria, bool getDataForExcelFile = false);
    }
}