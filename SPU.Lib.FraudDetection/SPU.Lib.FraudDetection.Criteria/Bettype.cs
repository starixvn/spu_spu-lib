using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fanex.NAP.Framework.Data;

namespace SPU.Lib.FraudDetection.Criteria
{
    public class Bettype:CriteriaBase
    {
        public int BettypeId { get; set; }

        public string BettypeName { get; set; }
    }
}
