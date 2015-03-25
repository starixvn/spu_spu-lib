using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fanex.NAP.Framework.Data;

namespace SPU.Lib.FraudDetection.Criteria
{
    public class SuspiciousInfo : CriteriaBase
    {
        public int CustId { get; set; }

        public int MatchId { get; set; }

        public int WorkflowId { get; set; }

        public string ListTransId { get; set; }
    }
}
