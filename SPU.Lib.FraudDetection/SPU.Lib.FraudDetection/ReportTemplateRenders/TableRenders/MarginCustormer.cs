using System.Collections.Generic;

namespace SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders
{
    public class MarginCustormer
    {
        public string Member { get; set; }

        public IList<double> Margins { get; set; }
    }
}