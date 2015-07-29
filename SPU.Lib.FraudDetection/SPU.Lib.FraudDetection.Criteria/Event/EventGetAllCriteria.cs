// --------------------------------------------------------------------------
// <copyright file="EventGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Criteria.Event
{
    using Fanex.Data.Repository;

    /// <summary>
    ///     EventSelectAllCriteria Class.
    /// </summary>
    public class EventGetAllCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "FD_EventGetAll";
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