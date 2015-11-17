// --------------------------------------------------------------------------
// <copyright file="TaskBackGroundGetByCaseIdCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.16.11">Created</change>
// </history>

namespace FD.Lib.Criteria.Task
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     TaskBackGroundGetByCaseIdCriteria Class.
    /// </summary>
    public class TaskBackGroundGetByCaseIdCriteria : CriteriaBase
    {
        public int CaseId { get; set; }

        /// <summary>
        ///     Get the reference SP's Name which is specified in Config file.
        /// </summary>
        /// <returns>The key of store procedure.</returns>
        public override string GetSettingKey()
        {
            return "FD_TaskBackGroundGetByCaseId";
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