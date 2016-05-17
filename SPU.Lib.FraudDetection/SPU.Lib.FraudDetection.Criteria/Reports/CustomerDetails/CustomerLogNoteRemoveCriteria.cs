// --------------------------------------------------------------------------
// <copyright file="CustomerLogNoteRemoveCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2016.05.14">Created</change>
// </history>

namespace FD.Lib.Criteria.Reports.CustomerDetails
{
    using Fanex.Data.Repository;

    public class CustomerLogNoteRemoveCriteria : CriteriaBase
    {
        public int CustomerLogId { get; set; }

        public int CreatorId { get; set; }

        public override string GetSettingKey()
        {
            return "FD_CustomerLogNoteRemove";
        }

        public override bool IsValid()
        {
            return CustomerLogId > 0;
        }
    }
}
