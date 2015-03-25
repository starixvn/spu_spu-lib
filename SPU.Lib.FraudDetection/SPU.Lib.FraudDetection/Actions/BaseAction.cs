using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPU.Lib.FraudDetection.Controller
{
    public abstract class BaseAction
    {
        protected int ActionID { get; set; }

        protected string ActionName { get; set; }

        protected bool IsActive { get; set; }

        public abstract bool takeAction();
    }
}
