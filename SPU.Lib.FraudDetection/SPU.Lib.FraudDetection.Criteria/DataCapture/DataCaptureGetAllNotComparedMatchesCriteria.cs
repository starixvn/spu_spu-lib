// --------------------------------------------------------------------------
// <copyright file="DataCaptureGetAllNotComparedMatchesCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.10.01">Created</change>
// </history>

namespace FD.Lib.Criteria.DataCapture
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     DataCaptureGetAllNotComparedMatchesCriteria Class.
    /// </summary>
    public class DataCaptureGetAllNotComparedMatchesCriteria : CriteriaBase
    {
        public string DataIdList { get; set; }

        public string MatchIdList { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_DataCaptureGetAllNotComparedMatches";
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