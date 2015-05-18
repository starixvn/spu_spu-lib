// --------------------------------------------------------------------------
// <copyright file="BettypeSelectAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// The criteria to select all supporting bet types.
    /// </summary>
    public class BettypeSelectAllCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "SPU_SBBettypeSelectAll";
        }
    }
}
