namespace SPU.Lib.FraudDetection.DTO.ReportTemplate
{
    using System.Collections.Generic;

    public class SuspiciousStatisticViewModel
    {
        public SuspiciousStatisticViewModel()
        {
            MarginCustormers = new List<MarginCustormer>();
            SuspiciousCustormers = new List<SuspiciousCustormer>();
        }

        public IList<MarginCustormer> MarginCustormers { get; set; }
        public IList<SuspiciousCustormer> SuspiciousCustormers { get; set; }
    }
}