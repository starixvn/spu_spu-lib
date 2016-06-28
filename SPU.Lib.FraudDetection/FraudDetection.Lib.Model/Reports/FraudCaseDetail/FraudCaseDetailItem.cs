namespace FD.Lib.Model.Reports.FraudCaseDetail
{
    public class FraudCaseDetailItem
    {
        private string formatLink = "<span class='all-ticketsip'>{0}</span>";

        public string CustName { get; set; }

        public long TransId { get; set; }

        public string TransDate { get; set; }

        public string BetType { get; set; }

        public string HomeName { get; set; }

        public string AwayName { get; set; }

        public string Odds { get; set; }

        public string Score { get; set; }

        public string Stake { get; set; }

        public decimal WinLoss { get; set; }

        public string Status { get; set; }

        public string Choice { get; set; }

        public string IP { get; set; }

        public int CaseId { get; set; }

        public string CaseName { get; set; }

        public string DisplayIP 
        { 
            get
            {
                return string.Format(formatLink, IP);
            }
        }
    }
}