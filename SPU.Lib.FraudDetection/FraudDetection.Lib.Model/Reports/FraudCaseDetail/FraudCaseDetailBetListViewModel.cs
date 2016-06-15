namespace FD.Lib.Model.Reports.FraudCaseDetail
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FraudCaseDetailBetListViewModel
    {
        public DateTime BalanceUpDay { get; set; }

        public IEnumerable<FraudCaseDetailItem> BetList { get; set; }
    }
}
