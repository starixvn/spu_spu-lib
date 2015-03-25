using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fanex.NAP.Framework.Data;

namespace SPU.Lib.FraudDetection.Criteria
{
    public class CustomerGroup : CriteriaBase
    {
        public int CustId { get; set; }

        public int GroupId { get; set; }
        
    }
}
