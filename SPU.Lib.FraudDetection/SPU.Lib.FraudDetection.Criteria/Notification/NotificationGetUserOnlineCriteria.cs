// --------------------------------------------------------------------------
// <copyright file="NotificationGetUserOnlineCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2016.07.11">Change to Case</change>
// </history>

namespace FD.Lib.Criteria.UserMesssage
{
    using Fanex.Data.Repository;

    public class NotificationGetUserOnlineCriteria : CriteriaBase
    {
        public int ExpiredTime { get; set; }

        public string UserIdList { get; set; }

        public override string GetSettingKey()
        {
            return "FD_NotificationGetUserOnline";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}