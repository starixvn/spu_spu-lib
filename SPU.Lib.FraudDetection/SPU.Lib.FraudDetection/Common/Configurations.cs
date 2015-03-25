// --------------------------------------------------------------------------
// <copyright file="Configurations.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// Configurations Class.
    /// </summary>
    public class Configurations
    {
        private Dictionary<string, ConfigInfo> _configs = new Dictionary<string, ConfigInfo>();

        public bool GetConfigurations()
        {
            return true;
        }

        public bool SetConfigInfo(ConfigInfo configInfo)
        {
            return true;
        }

        public bool UpdateConfigurations()
        {
            return true;
        }
    }
}
