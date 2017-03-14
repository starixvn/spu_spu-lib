namespace FD.Lib.Model.Reports.FraudCaseDetail
{
    using System.Collections.Generic;
    using System.Linq;

    public class FraudCaseDetailByBetTypeList
    {
        public string Bettype { get; set; }

        public List<FraudCaseDetailItem> FraudCaseDetailList { get; set; }
    }
}
