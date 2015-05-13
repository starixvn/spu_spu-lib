// --------------------------------------------------------------------------
// <copyright file="Config.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DTO
{
    /// <summary>
    /// ConfigInfo Class.
    /// </summary>
    public class Config
    {        
        public string ConfigName { get; set; }

        public string ConfigCategory { get; set; }

        public string ConfigControlType { get; set; }
    }
}
