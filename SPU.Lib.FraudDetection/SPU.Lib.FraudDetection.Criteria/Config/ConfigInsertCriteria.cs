// --------------------------------------------------------------------------
// <copyright file="ConfigInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// ConfigInsertCriteria Class.
    /// </summary>
    public class ConfigInsertCriteria : CriteriaBase
    {
        public string ConfigName { get; set; }

        public string ConfigValue { get; set; }

        public string ConfigOperator { get; set; }

        public override string GetSettingKey()
        {
            return string.Empty;
        }
    }
}
