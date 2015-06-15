using System.Collections.Generic;
using SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders;

namespace SPU.Lib.FraudDetection.ReportTemplateRenders
{
    public class SuspiciousStatisticViewModel
    {
        public IList<MarginCustormer> MarginCustormers { get; set; }

        public IList<SuspiciousCustormer> SuspiciousCustormers { get; set; }
    }
}