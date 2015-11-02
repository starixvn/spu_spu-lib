namespace FD.Lib.Model.Reports.FraudCaseDetail
{
    using System.Collections.Generic;

    public class FraudCaseDetailReportViewModel
    {
        public FraudCaseDetailSummary Summary { get; set; }

        public IList<FraudCaseDetailItem> Body { get; set; }
    }
}