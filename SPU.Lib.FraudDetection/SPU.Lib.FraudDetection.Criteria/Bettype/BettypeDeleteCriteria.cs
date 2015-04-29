// --------------------------------------------------------------------------
// <copyright file="BettypeDeleteCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria
{
    using SPU.Lib.FraudDetection.Criteria.Common;

    /// <summary>
    /// The criteria to delete a supporting bet type.
    /// </summary>
    public class BettypeDeleteCriteria : CriteriaBase
    {
        public int BettypeId { get; set; }        

        public override string GetSettingKey()
        {
            return string.Empty;
        }
    }
}
