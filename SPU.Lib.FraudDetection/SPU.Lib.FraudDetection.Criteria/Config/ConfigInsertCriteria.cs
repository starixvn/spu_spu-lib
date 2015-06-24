// --------------------------------------------------------------------------
// <copyright file="ConfigInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     ConfigInsertCriteria Class.
    /// </summary>
    public class ConfigInsertCriteria : CriteriaBase
    {
        public string ConfigName { get; set; }
        public string ConfigCategory { get; set; }
        public string ConfigControlType { get; set; }

        public override string GetSettingKey()
        {
            return string.Empty;
        }
    }
}