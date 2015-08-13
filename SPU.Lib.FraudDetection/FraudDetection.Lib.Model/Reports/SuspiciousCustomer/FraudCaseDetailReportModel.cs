namespace FD.Lib.Model.Reports.SuspiciousCustomer
{
    using System.Collections.Generic;
    using System.Security.AccessControl;

    public class FraudCaseDetailReportViewModel
    {
        public FraudCaseDetailSummary Summary { get; set; }

        public IList<FraudCaseDetailItem> Body { get; set; }
    }
}