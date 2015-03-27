// --------------------------------------------------------------------------
// <copyright file="ConfigInfo.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessObject
{
    /// <summary>
    /// ConfigInfo Class.
    /// </summary>
    public class Config
    {        
        public string ConfigName { get; set; }

        public string ConfigValue { get; set; }

        public string ConfigOperator { get; set; }

        public bool IsUpdate { get; set; }
    }
}
