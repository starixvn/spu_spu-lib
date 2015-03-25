using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPU.Lib.FraudDetection.Criteria;

namespace SPU.Lib.FraudDetection.Controller
{
    public class SupportedBettypes
    {
        public List<Bettype> supportedBettypes = new List<Bettype>();

        public bool getSupportedBettypes()
        {
            return true;
        }

        public bool insertSupportedBettypes()
        {
            return true;
        }
    }
}
