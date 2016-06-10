namespace FD.Lib.Model.Reports.FraudCaseDetail
{
    using System.Collections.Generic;
    using System.Linq;

    public class FraudCaseDetailReportViewModel
    {
        public FraudCaseDetailSummary Summary { get; set; }

        public List<FraudCaseDetailByBetTypeList> Body { get; set; }
    }
}