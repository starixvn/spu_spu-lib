using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPU.Lib.FraudDetection.Controller
{
    public class Configurations
    {
        public Dictionary<string, ConfigInfo> configs = new Dictionary<string, ConfigInfo>();

        public bool getConfigurations()
        {
            return true;
        }

        public bool setConfigInfo(ConfigInfo configInfo)
        {
            return true;
        }

        public bool updateConfigurations()
        {
            return true;
        }
    }
}
