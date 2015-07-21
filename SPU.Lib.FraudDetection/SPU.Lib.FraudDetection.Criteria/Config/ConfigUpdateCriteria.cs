// --------------------------------------------------------------------------
// <copyright file="ConfigUpdateCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.06.10">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Criteria.Config
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     ConfigUpdateCriteria Class.
    /// </summary>
    public class ConfigUpdateCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public string ListParamIDs { get; set; }

        public string ListParamNewValues { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "SPU_ConfigUpdate";
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