// --------------------------------------------------------------------------
// <copyright file="ConfigSelectAllCriteria.cs" company="Nexcel Solutions Vietnam">
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
    using SPU.Lib.FraudDetection.Criteria.Common;

    /// <summary>
    /// ConfigSelectAllCriteria Class.
    /// </summary>
    public class ConfigSelectAllCriteria : CriteriaBase
    {        
        public override string GetSettingKey()
        {
            return string.Empty;
        }
    }
}
