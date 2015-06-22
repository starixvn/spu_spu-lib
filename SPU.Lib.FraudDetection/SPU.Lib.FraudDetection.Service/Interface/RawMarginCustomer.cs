using System;

namespace SPU.Lib.FraudDetection.Service.Interface
{
    public class RawMarginCustomer
    {
        public int CustId { get; set; }

        public string Username { get; set; }

        public decimal? Margin { get; set; }

        public int SuspiciousMonth { get; set; }

        public int SuspiciousYear { get; set; }

        public DateTime WinlostDate
        {
            get
            {
               return new DateTime(SuspiciousYear, SuspiciousMonth, 1);
            }
        }
    }
}