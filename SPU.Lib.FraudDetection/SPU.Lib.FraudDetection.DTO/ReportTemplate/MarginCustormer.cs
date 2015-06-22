using System.Collections.Generic;

namespace SPU.Lib.FraudDetection.DTO.ReportTemplate
{
    public class MarginCustormer
    {
        public string Member { get; set; }

        public IList<decimal?> Margins { get; set; }

        public MarginCustormer()
        {
            Margins = new List<decimal?>();
        }
    }
}