using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPU.Lib.FraudDetection.Controller
{
    public class ActionAssignGroup: BaseAction
    {
        public int CustId { get; set; }

        public int GroupId { get; set; }

        public override bool takeAction()
        {
            throw new NotImplementedException();
        }
    }
}
