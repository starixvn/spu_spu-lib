// --------------------------------------------------------------------------
// <copyright file="NotificationInsertUserActionCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2016.07.11">Change to Case</change>
// </history>

namespace FD.Lib.Criteria.UserMesssage
{
    using Fanex.Data.Repository;

    public class NotificationInsertUserActionCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        public bool IsLogin { get; set; }

        public override string GetSettingKey()
        {
            return "FD_NotificationInsertUserAction";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}