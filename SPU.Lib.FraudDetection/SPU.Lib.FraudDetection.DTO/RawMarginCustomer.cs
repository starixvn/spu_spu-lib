namespace SPU.Lib.FraudDetection.DTO
{
    using System;

    public class RawMarginCustomer
    {
        public int CustId { get; set; }

        public string Username { get; set; }

        public decimal? MemberWinlost { get; set; }

        public decimal? Turnover { get; set; }

        public decimal? Margin
        {
            get
            {   
                if (!MemberWinlost.HasValue)
                    return null;
                if (!Turnover.HasValue)
                    return null;

                return MemberWinlost.Value/Turnover.Value;
            }
        }

        public int SuspiciousMonth { get; set; }

        public int SuspiciousYear { get; set; }

        public DateTime WinlostDate
        {
            get { return new DateTime(SuspiciousYear, SuspiciousMonth, 1); }
        }
    }
}