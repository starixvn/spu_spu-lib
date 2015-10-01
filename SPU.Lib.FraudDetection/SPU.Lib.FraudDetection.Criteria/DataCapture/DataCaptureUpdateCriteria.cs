// --------------------------------------------------------------------------
// <copyright file="DataCaptureUpdateCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.09.29">Created</change>
// </history>

namespace FD.Lib.Criteria.DataCapture
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     DataCaptureInsertCriteria Class.
    /// </summary>
    public class DataCaptureUpdateCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public string DataIdList { get; set; }

        public string MatchIdList { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_DataCaptureUpdate";
        }

        /// <summary>
        ///     Check data's constrains.
        /// </summary>
        /// <returns>True: valid; False: invalid.</returns>
        public override bool IsValid()
        {
            return true;
        }
    }
}