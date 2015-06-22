namespace SPU.Lib.FraudDetection.Service.Interface
{
    public class RawMarginCustomer
    {
        public int CustId { get; set; }

        public string Username { get; set; }

        public decimal Turnover { get; set; }

        public decimal MemberWinlost { get; set; }

        public int SuspiciousMonth { get; set; }
    }
}