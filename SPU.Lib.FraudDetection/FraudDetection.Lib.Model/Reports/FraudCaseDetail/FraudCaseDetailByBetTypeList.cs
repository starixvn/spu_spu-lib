namespace FD.Lib.Model.Reports.FraudCaseDetail
{
    using System.Linq;

    public class FraudCaseDetailByBetTypeList
    {
        public string Bettype { get; set; }

        public IGrouping<string, FraudCaseDetailItem> FraudCaseDetailList { get; set; }
    }
}
