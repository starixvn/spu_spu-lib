// --------------------------------------------------------------------------
// <copyright file="ResultCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria
{
    using SPU.Lib.FraudDetection.Criteria.Common;

    /// <summary>
    /// Result Criteria.
    /// </summary>
    public class ResultCriteria : CriteriaBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultCriteria"/> class.
        /// </summary>
        public ResultCriteria()
        {
            ErrCode = 0;
            ErrMsg = string.Empty;
        }

        public int ErrCode { get; set; }

        public string ErrMsg { get; set; }
    }
}
