namespace SPU.Lib.FraudDetection.DTO.ReportTemplate
{
    using System.Collections.Generic;

    public class MarginCustormer
    {
        public MarginCustormer()
        {
            Margins = new List<decimal?>();
        }

        public string Member { get; set; }
        public IList<decimal?> Margins { get; set; }
    }
}