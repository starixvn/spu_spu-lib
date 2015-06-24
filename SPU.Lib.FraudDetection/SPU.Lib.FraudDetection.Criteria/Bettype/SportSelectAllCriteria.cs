// --------------------------------------------------------------------------
// <copyright file="SportSelectAllCriteria.cs" company="Nexcel Solutions Vietnam">
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
    ///     The criteria to select all supporting bet types.
    /// </summary>
    public class SportSelectAllCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "SPU_SBSportSelectAll";
        }
    }
}