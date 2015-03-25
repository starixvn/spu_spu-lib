using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPU.Lib.FraudDetection.Controller
{
    public class ConfigInfo
    {
        public string ConfigName { get; set; }

        public string ConfigValue { get; set; }

        public string ConfigOperator { get; set; }

        public bool IsUpdate { get; set; }
    }
}
