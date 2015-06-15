using System.Collections.Generic;

namespace SPU.Lib.FraudDetection.DTO.ReportTemplate
{
    public class MarginCustormer
    {
        public string Member { get; set; }

        public IList<double> Margins { get; set; }
    }
}