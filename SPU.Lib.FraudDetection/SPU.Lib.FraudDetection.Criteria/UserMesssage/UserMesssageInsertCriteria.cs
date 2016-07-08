// --------------------------------------------------------------------------
// <copyright file="CaseInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2016.07.08">Change to Case</change>
// </history>

namespace FD.Lib.Criteria.Case
{
    using Fanex.Data.Repository;

    public class UserMesssageInsertCriteria : CriteriaBase
    {
        public int CreatorId { get; set; }

        public string UserMesssageDoc { get; set; }

        public override string GetSettingKey()
        {
            return "FD_UserMesssageInsert";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}