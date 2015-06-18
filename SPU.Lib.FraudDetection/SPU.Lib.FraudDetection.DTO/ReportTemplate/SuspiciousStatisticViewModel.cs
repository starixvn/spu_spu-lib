using System.Collections.Generic;

namespace SPU.Lib.FraudDetection.DTO.ReportTemplate
{
    public class SuspiciousStatisticViewModel
    {
        public IList<MarginCustormer> MarginCustormers { get; set; }

        public IList<SuspiciousCustormer> SuspiciousCustormers { get; set; }

        public SuspiciousStatisticViewModel()
        {
            MarginCustormers = new List<MarginCustormer>();
            SuspiciousCustormers = new List<SuspiciousCustormer>();
        }
    }
}