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
    ///     Config Info Class.
    /// </summary>
    public class Config
    {
        public int ConfigId { get; set; }
        public string ConfigName { get; set; }
        public string ConfigCategory { get; set; }
        public string ConfigControlType { get; set; }
        public string ConfigSQLTable { get; set; }
        public string ConfigSQLField { get; set; }
        public string ConfigSQLReturn { get; set; }
    }
}